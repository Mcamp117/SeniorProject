using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Models
{
    public class Connection
    {
        public int Id { get; set; }
        
        [Required]
        public string User1Id { get; set; } = string.Empty;
        
        [Required]
        public string User2Id { get; set; } = string.Empty;
        
        public ConnectionStatus Status { get; set; } = ConnectionStatus.Pending;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? AcceptedAt { get; set; }
        
        // Navigation properties
        public ApplicationUser? User1 { get; set; }
        public ApplicationUser? User2 { get; set; }
        
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }

    public enum ConnectionStatus
    {
        Pending,
        Accepted,
        Declined,
        Blocked
    }
}

