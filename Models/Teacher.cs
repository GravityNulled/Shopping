namespace StudentsApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public long PhoneNumber { get; set; }

        public ICollection<Unit> Units { get; set; } = null!;
    }
}