using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class StudentOrganization
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string ContactEmail { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Website { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [StringLength(200)]
        public string MeetingSchedule { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<StudentOrganizationMember> Members { get; set; } = new List<StudentOrganizationMember>();
    }

    public class StudentOrganizationMember
    {
        public int OrganizationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string Role { get; set; } = "Member"; // Member, Officer, President, Vice-President, etc.
        
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public StudentOrganization? Organization { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
