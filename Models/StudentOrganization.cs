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
        
        // Moderator (assigned by admin)
        public string? ModeratorId { get; set; }
        public ApplicationUser? Moderator { get; set; }
        
        // Navigation properties
        public ICollection<StudentOrganizationMember> Members { get; set; } = new List<StudentOrganizationMember>();
        public ICollection<OrganizationMembershipRequest> MembershipRequests { get; set; } = new List<OrganizationMembershipRequest>();
        public ICollection<OrganizationPost> Posts { get; set; } = new List<OrganizationPost>();
        public ICollection<OrganizationMessage> Messages { get; set; } = new List<OrganizationMessage>();
    }

    public class StudentOrganizationMember
    {
        public int OrganizationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string Role { get; set; } = "Member"; // Member, Moderator
        
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public StudentOrganization? Organization { get; set; }
        public ApplicationUser? User { get; set; }
    }

    public class OrganizationMembershipRequest
    {
        public int Id { get; set; }
        
        public int OrganizationId { get; set; }
        public StudentOrganization? Organization { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        
        [StringLength(500)]
        public string Message { get; set; } = string.Empty; // Optional message from user
        
        public MembershipRequestStatus Status { get; set; } = MembershipRequestStatus.Pending;
        
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? ProcessedAt { get; set; }
        
        public string? ProcessedById { get; set; }
        public ApplicationUser? ProcessedBy { get; set; }
        
        [StringLength(500)]
        public string? RejectionReason { get; set; }
    }

    public enum MembershipRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class OrganizationPost
    {
        public int Id { get; set; }
        
        public int OrganizationId { get; set; }
        public StudentOrganization? Organization { get; set; }
        
        [Required]
        public string AuthorId { get; set; } = string.Empty;
        public ApplicationUser? Author { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(5000)]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        public bool IsPinned { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
    }

    public class OrganizationMessage
    {
        public int Id { get; set; }
        
        public int OrganizationId { get; set; }
        public StudentOrganization? Organization { get; set; }
        
        [Required]
        public string SenderId { get; set; } = string.Empty;
        public ApplicationUser? Sender { get; set; }
        
        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;
        
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
