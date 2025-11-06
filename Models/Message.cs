using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required]
        public int ConnectionId { get; set; }
        
        [Required]
        public string SenderId { get; set; } = string.Empty;
        
        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;
        
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        
        public bool IsRead { get; set; } = false;
        
        public DateTime? ReadAt { get; set; }
        
        // Navigation properties
        public Connection? Connection { get; set; }
        public ApplicationUser? Sender { get; set; }
    }
}

