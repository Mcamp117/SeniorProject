using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class ConnectionPost
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;
        
        public ConnectionType Type { get; set; }
        
        public SeekingType Seeking { get; set; } // What they're looking for
        
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;
        
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? Deadline { get; set; }
        
        [Required]
        public string PosterId { get; set; } = string.Empty;
        
        public PostStatus Status { get; set; } = PostStatus.Active;
        
        [StringLength(1000)]
        public string Skills { get; set; } = string.Empty; // JSON string of skills
        
        [StringLength(1000)]
        public string Requirements { get; set; } = string.Empty; // JSON string of requirements
        
        [StringLength(200)]
        public string ContactInfo { get; set; } = string.Empty;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation properties
        public ApplicationUser? Poster { get; set; }
    }

    public enum ConnectionType
    {
        Mentorship,
        StudyPartner,
        ProjectCollaboration,
        Networking,
        Research,
        Internship,
        Volunteer,
        Other
    }

    public enum SeekingType
    {
        Mentor,
        Mentee,
        StudyPartner,
        Collaborator,
        Network,
        ResearchPartner,
        Intern,
        Volunteer,
        Other
    }

    public enum PostStatus
    {
        Active,
        Closed,
        Pending
    }
}
