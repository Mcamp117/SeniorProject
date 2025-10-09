using EagleConnect.Models;

namespace EagleConnect.Services
{
    public class StaticDataService
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Relationship> Relationships { get; set; } = new List<Relationship>();
        public List<ConnectionPost> ConnectionPosts { get; set; } = new List<ConnectionPost>();
        public List<StudentOrganization> Organizations { get; set; } = new List<StudentOrganization>();

        public StaticDataService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Initialize Users
            Users = new List<User>
            {
                // Students
                new User { Id = 1, FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@usi.edu", Type = UserType.Student, Major = "Computer Science", Year = "Junior", Bio = "Passionate about software development and AI", Skills = new List<string> { "C#", "JavaScript", "Python" }, ProfileImage = "/images/student1.jpg" },
                new User { Id = 2, FirstName = "Michael", LastName = "Chen", Email = "michael.chen@usi.edu", Type = UserType.Student, Major = "Business Administration", Year = "Sophomore", Bio = "Interested in entrepreneurship and marketing", Skills = new List<string> { "Marketing", "Leadership", "Analytics" }, ProfileImage = "/images/student2.jpg" },
                new User { Id = 3, FirstName = "Emily", LastName = "Rodriguez", Email = "emily.rodriguez@usi.edu", Type = UserType.Student, Major = "Nursing", Year = "Senior", Bio = "Future nurse with a passion for helping others", Skills = new List<string> { "Patient Care", "Medical Knowledge", "Communication" }, ProfileImage = "/images/student3.jpg" },
                new User { Id = 4, FirstName = "David", LastName = "Wilson", Email = "david.wilson@usi.edu", Type = UserType.Student, Major = "Engineering", Year = "Freshman", Bio = "New to USI, looking to connect with peers", Skills = new List<string> { "Mathematics", "Problem Solving" }, ProfileImage = "/images/student4.jpg" },
                new User { Id = 5, FirstName = "Jessica", LastName = "Brown", Email = "jessica.brown@usi.edu", Type = UserType.Student, Major = "Psychology", Year = "Junior", Bio = "Studying human behavior and mental health", Skills = new List<string> { "Research", "Counseling", "Analysis" }, ProfileImage = "/images/student5.jpg" },

                // Alumni
                new User { Id = 6, FirstName = "Robert", LastName = "Smith", Email = "robert.smith@company.com", Type = UserType.Alumni, Major = "Computer Science", GraduationYear = 2018, Bio = "Software Engineer at Microsoft, passionate about mentoring", Skills = new List<string> { "C#", "Azure", "Leadership", "Mentoring" }, Company = "Microsoft", JobTitle = "Senior Software Engineer", ProfileImage = "/images/alumni1.jpg" },
                new User { Id = 7, FirstName = "Lisa", LastName = "Anderson", Email = "lisa.anderson@company.com", Type = UserType.Alumni, Major = "Business Administration", GraduationYear = 2015, Bio = "Marketing Director helping students with career guidance", Skills = new List<string> { "Marketing", "Strategy", "Leadership", "Networking" }, Company = "Procter & Gamble", JobTitle = "Marketing Director", ProfileImage = "/images/alumni2.jpg" },
                new User { Id = 8, FirstName = "James", LastName = "Taylor", Email = "james.taylor@company.com", Type = UserType.Alumni, Major = "Nursing", GraduationYear = 2020, Bio = "Registered Nurse at local hospital, loves giving back", Skills = new List<string> { "Patient Care", "Medical Knowledge", "Teaching", "Mentoring" }, Company = "Deaconess Hospital", JobTitle = "Registered Nurse", ProfileImage = "/images/alumni3.jpg" },

                // Faculty
                new User { Id = 9, FirstName = "Dr. Maria", LastName = "Garcia", Email = "maria.garcia@usi.edu", Type = UserType.Faculty, Major = "Computer Science", Bio = "Professor of Computer Science, research in AI and machine learning", Skills = new List<string> { "AI", "Machine Learning", "Research", "Teaching" }, Company = "University of Southern Indiana", JobTitle = "Professor", ProfileImage = "/images/faculty1.jpg" },
                new User { Id = 10, FirstName = "Dr. John", LastName = "Davis", Email = "john.davis@usi.edu", Type = UserType.Faculty, Major = "Business", Bio = "Business professor specializing in entrepreneurship", Skills = new List<string> { "Entrepreneurship", "Business Strategy", "Teaching", "Mentoring" }, Company = "University of Southern Indiana", JobTitle = "Associate Professor", ProfileImage = "/images/faculty2.jpg" },

                // External Users
                new User { Id = 11, FirstName = "Alex", LastName = "Thompson", Email = "alex.thompson@techcorp.com", Type = UserType.External, Bio = "Tech recruiter looking to connect with talented students", Skills = new List<string> { "Recruiting", "Networking", "Career Development" }, Company = "TechCorp", JobTitle = "Senior Recruiter", ProfileImage = "/images/external1.jpg" },
                new User { Id = 12, FirstName = "Rachel", LastName = "Miller", Email = "rachel.miller@startup.com", Type = UserType.External, Bio = "Startup founder offering internship opportunities", Skills = new List<string> { "Entrepreneurship", "Startups", "Innovation" }, Company = "InnovateStart", JobTitle = "Founder & CEO", ProfileImage = "/images/external2.jpg" }
            };

            // Initialize Relationships
            Relationships = new List<Relationship>
            {
                new Relationship { Id = 1, MentorId = 6, MenteeId = 1, Type = RelationshipType.AlumniStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-30), Notes = "Helping with software development career guidance" },
                new Relationship { Id = 2, MentorId = 7, MenteeId = 2, Type = RelationshipType.AlumniStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-15), Notes = "Business career mentoring and networking" },
                new Relationship { Id = 3, MentorId = 8, MenteeId = 3, Type = RelationshipType.AlumniStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-20), Notes = "Nursing career guidance and clinical experience" },
                new Relationship { Id = 4, MentorId = 11, MenteeId = 1, Type = RelationshipType.ExternalStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-10), Notes = "Tech industry career opportunities" },
                new Relationship { Id = 5, MentorId = 12, MenteeId = 2, Type = RelationshipType.ExternalStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-5), Notes = "Startup internship opportunity" },
                new Relationship { Id = 6, MentorId = 1, MenteeId = 4, Type = RelationshipType.StudentStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-7), Notes = "Computer Science peer mentoring" },
                new Relationship { Id = 7, MentorId = 3, MenteeId = 5, Type = RelationshipType.StudentStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-12), Notes = "Study group leadership" },
                new Relationship { Id = 8, MentorId = 9, MenteeId = 1, Type = RelationshipType.FacultyStudent, Status = "Active", CreatedDate = DateTime.Now.AddDays(-25), Notes = "Research project collaboration" }
            };

            // Initialize Connection Posts
            ConnectionPosts = new List<ConnectionPost>
            {
                // Alumni seeking mentees
                new ConnectionPost { Id = 1, Title = "Software Engineering Mentor Available", Description = "I'm a Senior Software Engineer at Microsoft with 5+ years of experience. Looking to mentor Computer Science students who are passionate about software development and want career guidance.", Type = ConnectionType.Mentorship, Seeking = SeekingType.Mentee, Location = "Virtual/On-campus", PostedDate = DateTime.Now.AddDays(-1), PosterId = 6, Status = PostStatus.Active, Skills = new List<string> { "C#", "Azure", "Leadership", "Career Development" }, Requirements = new List<string> { "Computer Science major", "Junior or Senior level", "Passionate about software development" }, ContactInfo = "robert.smith@company.com" },
                
                // Student seeking mentor
                new ConnectionPost { Id = 2, Title = "CS Student Looking for Tech Mentor", Description = "I'm a Junior Computer Science student at USI looking for a mentor in the tech industry. I'm particularly interested in AI/ML and would love guidance on career paths and skill development.", Type = ConnectionType.Mentorship, Seeking = SeekingType.Mentor, Location = "Virtual preferred", PostedDate = DateTime.Now.AddDays(-2), PosterId = 1, Status = PostStatus.Active, Skills = new List<string> { "Python", "JavaScript", "Machine Learning" }, Requirements = new List<string> { "Tech industry experience", "AI/ML knowledge preferred", "Available for monthly meetings" }, ContactInfo = "sarah.johnson@usi.edu" },
                
                // Alumni seeking mentees
                new ConnectionPost { Id = 3, Title = "Marketing Director Offering Career Guidance", Description = "As a Marketing Director at P&G, I'm looking to mentor Business students interested in marketing careers. I can provide insights into the industry and help with professional development.", Type = ConnectionType.Mentorship, Seeking = SeekingType.Mentee, Location = "Virtual", PostedDate = DateTime.Now.AddDays(-3), PosterId = 7, Status = PostStatus.Active, Skills = new List<string> { "Marketing Strategy", "Brand Management", "Leadership", "Networking" }, Requirements = new List<string> { "Business or Marketing major", "Interest in consumer goods", "Strong communication skills" }, ContactInfo = "lisa.anderson@company.com" },
                
                // Student seeking study partner
                new ConnectionPost { Id = 4, Title = "Looking for Study Partner - Strategic Management", Description = "I'm a Sophomore Business student looking for a study partner for Strategic Management. We can meet weekly to discuss case studies and prepare for exams together.", Type = ConnectionType.StudyPartner, Seeking = SeekingType.StudyPartner, Location = "Library or Virtual", PostedDate = DateTime.Now.AddDays(-1), PosterId = 2, Status = PostStatus.Active, Skills = new List<string> { "Business Analysis", "Case Study Review", "Group Study" }, Requirements = new List<string> { "Business major", "Taking Strategic Management", "Available weekends" }, ContactInfo = "michael.chen@usi.edu" },
                
                // Faculty seeking research collaborators
                new ConnectionPost { Id = 5, Title = "AI Research Project - Seeking Student Collaborators", Description = "I'm a Computer Science professor looking for motivated students to collaborate on AI research projects. This is a great opportunity to gain research experience and potentially publish papers.", Type = ConnectionType.Research, Seeking = SeekingType.ResearchPartner, Location = "Computer Science Building", PostedDate = DateTime.Now.AddDays(-4), PosterId = 9, Status = PostStatus.Active, Skills = new List<string> { "Python", "Machine Learning", "Research Methods", "Data Analysis" }, Requirements = new List<string> { "Computer Science major", "Strong programming skills", "GPA 3.5+", "Available 10+ hours/week" }, ContactInfo = "maria.garcia@usi.edu" },
                
                // Student seeking mentor
                new ConnectionPost { Id = 6, Title = "Nursing Student Needs Clinical Mentor", Description = "I'm a Senior Nursing student preparing for clinical rotations. I'm looking for an experienced nurse who can provide guidance on patient care, clinical skills, and career advice in healthcare.", Type = ConnectionType.Mentorship, Seeking = SeekingType.Mentor, Location = "Evansville area", PostedDate = DateTime.Now.AddDays(-2), PosterId = 3, Status = PostStatus.Active, Skills = new List<string> { "Patient Care", "Clinical Skills", "Healthcare Knowledge" }, Requirements = new List<string> { "Registered Nurse with 3+ years experience", "Available for monthly meetings", "Passionate about teaching" }, ContactInfo = "emily.rodriguez@usi.edu" },
                
                // External professional seeking mentees
                new ConnectionPost { Id = 7, Title = "Tech Recruiter Offering Career Coaching", Description = "I'm a Senior Tech Recruiter looking to help students navigate the tech job market. I can provide resume reviews, interview prep, and networking opportunities in the tech industry.", Type = ConnectionType.Mentorship, Seeking = SeekingType.Mentee, Location = "Virtual", PostedDate = DateTime.Now.AddDays(-5), PosterId = 11, Status = PostStatus.Active, Skills = new List<string> { "Recruiting", "Career Development", "Tech Industry", "Networking" }, Requirements = new List<string> { "Any major welcome", "Interest in tech careers", "Motivated to learn" }, ContactInfo = "alex.thompson@techcorp.com" },
                
                // Student seeking project collaborator
                new ConnectionPost { Id = 8, Title = "Startup Project - Need Business Partner", Description = "I'm working on a startup idea and need a Business student to help with market research, business plan development, and strategy. This could lead to a real business opportunity!", Type = ConnectionType.ProjectCollaboration, Seeking = SeekingType.Collaborator, Location = "Innovation Center", PostedDate = DateTime.Now.AddDays(-3), PosterId = 2, Status = PostStatus.Active, Skills = new List<string> { "Entrepreneurship", "Market Research", "Business Strategy" }, Requirements = new List<string> { "Business major", "Entrepreneurial mindset", "Available 5+ hours/week" }, ContactInfo = "michael.chen@usi.edu" }
            };

            // Initialize Student Organizations
            Organizations = new List<StudentOrganization>
            {
                new StudentOrganization { Id = 1, Name = "Computer Science Club", Description = "Promoting computer science education and networking", Category = "Academic", ContactEmail = "csclub@usi.edu", Website = "www.usicsclub.com", MemberIds = new List<int> { 1, 4, 6, 9 }, OfficerIds = new List<int> { 1, 6 }, CreatedDate = DateTime.Now.AddDays(-100), MeetingSchedule = "Every Friday 5:00 PM", Location = "Computer Science Building Room 301" },
                new StudentOrganization { Id = 2, Name = "Business Student Association", Description = "Connecting business students with industry professionals", Category = "Professional", ContactEmail = "bsa@usi.edu", Website = "www.usibsa.com", MemberIds = new List<int> { 2, 7, 10 }, OfficerIds = new List<int> { 2, 7 }, CreatedDate = DateTime.Now.AddDays(-80), MeetingSchedule = "Every Wednesday 6:00 PM", Location = "Business Building Room 205" },
                new StudentOrganization { Id = 3, Name = "Nursing Student Association", Description = "Supporting nursing students through their academic journey", Category = "Academic", ContactEmail = "nsa@usi.edu", Website = "www.usinsa.com", MemberIds = new List<int> { 3, 5, 8 }, OfficerIds = new List<int> { 3, 8 }, CreatedDate = DateTime.Now.AddDays(-60), MeetingSchedule = "Every Tuesday 7:00 PM", Location = "Health Sciences Building Room 150" },
                new StudentOrganization { Id = 4, Name = "Entrepreneurship Society", Description = "Fostering innovation and startup culture", Category = "Professional", ContactEmail = "entrepreneurship@usi.edu", Website = "www.usientrepreneurship.com", MemberIds = new List<int> { 2, 12, 10 }, OfficerIds = new List<int> { 2, 12 }, CreatedDate = DateTime.Now.AddDays(-40), MeetingSchedule = "Every Monday 5:30 PM", Location = "Innovation Center" }
            };
        }

        public User? GetUserById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsersByType(UserType type)
        {
            return Users.Where(u => u.Type == type).ToList();
        }

        public List<Relationship> GetRelationshipsByType(RelationshipType type)
        {
            return Relationships.Where(r => r.Type == type).ToList();
        }

        public List<ConnectionPost> GetActiveConnectionPosts()
        {
            return ConnectionPosts.Where(cp => cp.Status == PostStatus.Active).ToList();
        }

        public List<ConnectionPost> GetConnectionPostsByType(ConnectionType type)
        {
            return ConnectionPosts.Where(cp => cp.Type == type).ToList();
        }

        public List<ConnectionPost> GetConnectionPostsBySeeking(SeekingType seeking)
        {
            return ConnectionPosts.Where(cp => cp.Seeking == seeking).ToList();
        }

        public List<ConnectionPost> GetConnectionPostsByPoster(int posterId)
        {
            return ConnectionPosts.Where(cp => cp.PosterId == posterId).ToList();
        }

        public List<StudentOrganization> GetOrganizationsByCategory(string category)
        {
            return Organizations.Where(o => o.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
