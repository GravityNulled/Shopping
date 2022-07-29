namespace StudentsApi.Models
{
    public class Identification
    {
        public int Id { get; set; }
        public DateTime IssueDatate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}