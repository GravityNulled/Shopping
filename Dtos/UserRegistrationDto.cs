namespace StudentsApi.Dtos
{
    public class UserRegistrationDto
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}