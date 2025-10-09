namespace EagleConnect.Models
{
    public class ConnectionPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ConnectionType Type { get; set; }
        public SeekingType Seeking { get; set; } // What they're looking for
        public string Location { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int PosterId { get; set; }
        public PostStatus Status { get; set; } = PostStatus.Active;
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> Requirements { get; set; } = new List<string>();
        public string ContactInfo { get; set; } = string.Empty;
        public User? Poster { get; set; }
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
