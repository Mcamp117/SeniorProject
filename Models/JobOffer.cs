using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(3000)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [StringLength(3000)]
        public string Responsibilities { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Link { get; set; } = string.Empty;
        
        [Required]
        public DateTime ApplicationDeadline { get; set; }
        
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        [Required]
        public string PosterId { get; set; } = string.Empty;
        
        public JobOfferStatus Status { get; set; } = JobOfferStatus.Active;
        
        [StringLength(100)]
        public string? CompanyName { get; set; }
        
        [StringLength(200)]
        public string? Location { get; set; }
        
        // Navigation properties
        public ApplicationUser? Poster { get; set; }
    }

    public enum JobOfferStatus
    {
        Active,
        Closed,
        Expired
    }
}

