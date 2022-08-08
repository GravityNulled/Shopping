using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentsApi.Dtos;
using StudentsApi.Models;

namespace StudentsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        public AuthController(UserManager<IdentityUser> usermanager, IConfiguration config)
        {
            _userManager = usermanager;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserRegistrationDto>> Register(UserRegistrationDto userRegistration)
        {
            if (ModelState.IsValid)
            {
                var user_exist = await _userManager.FindByEmailAsync(userRegistration.Email);
                if (user_exist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Error = "User Exists",
                        Result = false
                    });
                }
                var user = new IdentityUser()
                {
                    Email = userRegistration.Email,
                    PhoneNumber = userRegistration.PhoneNumber,
                    UserName = userRegistration.UserName
                };
                var createdUser = await _userManager.CreateAsync(user, userRegistration.Password);
                if (createdUser.Succeeded)
                {
                    var token = GenerateToken(user);
                    return Ok(new AuthResult()
                    {
                        Token = token,
                        Result = true
                    });
                }
                return BadRequest(new AuthResult()
                {
                    Error = "Server Error",
                    Result = false
                });
            }
            return BadRequest(new AuthResult()
            {
                Error = "Payload Fail",
                Result = false
            });
        }

        [NonAction]
        public string GenerateToken(IdentityUser user)
        {
            var key = Encoding.UTF8.GetBytes(_config.GetSection("JwtConfig:Secret").Value);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Iat, new DateTime().ToUniversalTime().ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}