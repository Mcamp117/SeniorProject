using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        public SkillCategory Category { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation properties
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    }

    public enum SkillCategory
    {
        Academic,
        Technical,
        Soft,
        Professional,
        Certification,
        Language,
        Other
    }

    public class UserSkill
    {
        public string UserId { get; set; } = string.Empty;
        public int SkillId { get; set; }
        
        [StringLength(50)]
        public string ProficiencyLevel { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced, Expert
        
        public DateTime AcquiredDate { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public ApplicationUser? User { get; set; }
        public Skill? Skill { get; set; }
    }
}

