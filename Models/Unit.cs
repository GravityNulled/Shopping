namespace StudentsApi.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string DataBase { get; set; } = null!;
        public string Mathematics { get; set; } = null!;
        public string Csharp { get; set; } = null!;
        public string ComputerApplications { get; set; }  = null!;
        public ICollection<Student> Students { get; set; } = null!;
        public ICollection<Teacher> Teachers { get; set; } = null!;
    }
}