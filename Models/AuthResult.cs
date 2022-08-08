namespace StudentsApi.Models
{
    public class AuthResult
    {
        public string Token { get; set; } = null!;
        public string Error { get; set; } = null!;
        public bool Result { get; set; }
    }
}