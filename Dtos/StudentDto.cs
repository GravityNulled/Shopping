namespace StudentsApi.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
    }
}