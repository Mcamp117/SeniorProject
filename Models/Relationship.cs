namespace EagleConnect.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public int MenteeId { get; set; }
        public RelationshipType Type { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public User? Mentor { get; set; }
        public User? Mentee { get; set; }
    }

    public enum RelationshipType
    {
        AlumniStudent,
        ExternalStudent,
        StudentStudent,
        FacultyStudent
    }
}
