namespace StudentsApi.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        // public ICollection<Student> Students { get; set; } = null!;
        // public ICollection<Teacher> Teachers { get; set; } = null!;
    }
}