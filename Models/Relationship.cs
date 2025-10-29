using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        
        [Required]
        public string MentorId { get; set; } = string.Empty;
        
        [Required]
        public string MenteeId { get; set; } = string.Empty;
        
        public RelationshipType Type { get; set; }
        
        [StringLength(20)]
        public string Status { get; set; } = "Pending";
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        public DateTime? StartedDate { get; set; }
        
        public DateTime? EndedDate { get; set; }
        
        // Navigation properties
        public ApplicationUser? Mentor { get; set; }
        public ApplicationUser? Mentee { get; set; }
    }

    public enum RelationshipType
    {
        AlumniStudent,
        ExternalStudent,
        StudentStudent,
        FacultyStudent
    }
}
