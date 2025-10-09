namespace EagleConnect.Models
{
    public class StudentOrganization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public List<int> MemberIds { get; set; } = new List<int>();
        public List<int> OfficerIds { get; set; } = new List<int>();
        public DateTime CreatedDate { get; set; }
        public string MeetingSchedule { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<User> Members { get; set; } = new List<User>();
        public List<User> Officers { get; set; } = new List<User>();
    }
}
