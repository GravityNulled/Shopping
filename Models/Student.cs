using System.Text.Json.Serialization;

namespace StudentsApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public Identification IdNumber { get; set; } = null!;
    }
}