namespace StudentsApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public ICollection<Unit> Units { get; set; } = null!;
        public Identification IDNumbers { get; set; } = null!;
    }
}