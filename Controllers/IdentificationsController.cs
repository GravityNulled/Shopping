using Microsoft.AspNetCore.Mvc;
using StudentsApi.Interfaces;
using StudentsApi.Models;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationsController : ControllerBase
    {
        private readonly IIdentificationRepository _identificationRepository;
        public IdentificationsController(IIdentificationRepository identificationRepository)
        {
            _identificationRepository = identificationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Identification>> GetAll()
        {
            var ids = await _identificationRepository.GetAll();
            return Ok(ids);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Identification>> GetByIdAsync(int id)
        {
            var identification = await _identificationRepository.GetByIdAsync(id);
            if (identification == null) return NotFound();
            return Ok(identification);
        }

        [HttpPost]
        public async Task<ActionResult<Identification>> Post([FromBody] Identification identification)
        {
            await _identificationRepository.CreateAsync(identification);
            return CreatedAtAction("GetAll", identification.Id, identification);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Identification>> Delete(int id)
        {
            var idToDelete = await _identificationRepository.Delete(id);
            return Ok(idToDelete);
        }
    }
}