namespace EagleConnect.Models
{
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

    public enum UserType
    {
        Student,
        Alumni,
        Faculty,
        External
    }
}
