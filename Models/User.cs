using Microsoft.AspNetCore.Identity;

namespace EagleConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserType Type { get; set; }
        public string Year { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = "/images/default-avatar.svg";
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public int GraduationYear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation properties
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
        public ICollection<Relationship> MentorRelationships { get; set; } = new List<Relationship>();
        public ICollection<Relationship> MenteeRelationships { get; set; } = new List<Relationship>();
        public ICollection<ConnectionPost> ConnectionPosts { get; set; } = new List<ConnectionPost>();
        public ICollection<StudentOrganizationMember> OrganizationMemberships { get; set; } = new List<StudentOrganizationMember>();
    }

    public enum UserType
    {
        Student,
        Alumni,
        Faculty,
        External
    }

    // Keep the original User class for backward compatibility if needed
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserType Type { get; set; }
        public string Major { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new List<string>();
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public int GraduationYear { get; set; }
    }
}
