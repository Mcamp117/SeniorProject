using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EagleConnect.Models;

namespace EagleConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core tables
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<StudentOrganization> StudentOrganizations { get; set; }
        public DbSet<StudentOrganizationMember> StudentOrganizationMembers { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<ConnectionPost> ConnectionPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure ApplicationUser
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Year).HasMaxLength(20);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.ProfileImage).HasMaxLength(255).HasDefaultValue("/images/default-avatar.svg");
                entity.Property(e => e.Company).HasMaxLength(100);
                entity.Property(e => e.JobTitle).HasMaxLength(100);
            });

            // Configure Skill
            builder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Configure UserSkill (many-to-many relationship)
            builder.Entity<UserSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SkillId });
                entity.Property(e => e.ProficiencyLevel).HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(500);
                
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserSkills)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.Skill)
                    .WithMany(s => s.UserSkills)
                    .HasForeignKey(e => e.SkillId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure StudentOrganization
            builder.Entity<StudentOrganization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Category).HasMaxLength(50);
                entity.Property(e => e.ContactEmail).HasMaxLength(100);
                entity.Property(e => e.Website).HasMaxLength(200);
                entity.Property(e => e.MeetingSchedule).HasMaxLength(200);
                entity.Property(e => e.Location).HasMaxLength(200);
            });

            // Configure StudentOrganizationMember (many-to-many relationship)
            builder.Entity<StudentOrganizationMember>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.UserId });
                entity.Property(e => e.Role).HasMaxLength(50);
                
                entity.HasOne(e => e.Organization)
                    .WithMany(o => o.Members)
                    .HasForeignKey(e => e.OrganizationId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.User)
                    .WithMany(u => u.OrganizationMemberships)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Relationship
            builder.Entity<Relationship>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MentorId).IsRequired();
                entity.Property(e => e.MenteeId).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.Notes).HasMaxLength(500);
                
                entity.HasOne(e => e.Mentor)
                    .WithMany(u => u.MentorRelationships)
                    .HasForeignKey(e => e.MentorId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.Mentee)
                    .WithMany(u => u.MenteeRelationships)
                    .HasForeignKey(e => e.MenteeId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                // Prevent self-mentoring
                entity.ToTable(t => t.HasCheckConstraint("CK_Relationship_DifferentUsers", "MentorId != MenteeId"));
            });

            // Configure ConnectionPost
            builder.Entity<ConnectionPost>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.PosterId).IsRequired();
                entity.Property(e => e.Skills).HasMaxLength(1000);
                entity.Property(e => e.Requirements).HasMaxLength(1000);
                entity.Property(e => e.ContactInfo).HasMaxLength(200);
                
                entity.HasOne(e => e.Poster)
                    .WithMany(u => u.ConnectionPosts)
                    .HasForeignKey(e => e.PosterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed initial data
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            // Seed Skills
            var skills = new List<Skill>
            {
                // Academic Skills
                new Skill { Id = 1, Name = "Computer Science", Description = "Core computer science knowledge", Category = SkillCategory.Academic },
                new Skill { Id = 2, Name = "Business Administration", Description = "Business management and administration", Category = SkillCategory.Academic },
                new Skill { Id = 3, Name = "Nursing", Description = "Healthcare and patient care", Category = SkillCategory.Academic },
                new Skill { Id = 4, Name = "Engineering", Description = "Engineering principles and practices", Category = SkillCategory.Academic },
                new Skill { Id = 5, Name = "Psychology", Description = "Human behavior and mental health", Category = SkillCategory.Academic },
                new Skill { Id = 6, Name = "Accounting", Description = "Financial accounting and bookkeeping", Category = SkillCategory.Academic },
                new Skill { Id = 7, Name = "Marketing", Description = "Marketing strategies and techniques", Category = SkillCategory.Academic },
                new Skill { Id = 8, Name = "Finance", Description = "Financial management and analysis", Category = SkillCategory.Academic },
                new Skill { Id = 9, Name = "Mathematics", Description = "Mathematical concepts and problem solving", Category = SkillCategory.Academic },
                new Skill { Id = 10, Name = "Biology", Description = "Biological sciences and research", Category = SkillCategory.Academic },
                
                // Technical Skills
                new Skill { Id = 11, Name = "C#", Description = "C# programming language", Category = SkillCategory.Technical },
                new Skill { Id = 12, Name = "JavaScript", Description = "JavaScript programming language", Category = SkillCategory.Technical },
                new Skill { Id = 13, Name = "Python", Description = "Python programming language", Category = SkillCategory.Technical },
                new Skill { Id = 14, Name = "Azure", Description = "Microsoft Azure cloud platform", Category = SkillCategory.Technical },
                new Skill { Id = 15, Name = "Machine Learning", Description = "AI and machine learning techniques", Category = SkillCategory.Technical },
                new Skill { Id = 16, Name = "Data Analysis", Description = "Data analysis and visualization", Category = SkillCategory.Technical },
                new Skill { Id = 17, Name = "Web Development", Description = "Frontend and backend web development", Category = SkillCategory.Technical },
                new Skill { Id = 18, Name = "Database Management", Description = "Database design and management", Category = SkillCategory.Technical },
                
                // Soft Skills
                new Skill { Id = 19, Name = "Leadership", Description = "Leading teams and projects", Category = SkillCategory.Soft },
                new Skill { Id = 20, Name = "Communication", Description = "Effective communication skills", Category = SkillCategory.Soft },
                new Skill { Id = 21, Name = "Problem Solving", Description = "Analytical and creative problem solving", Category = SkillCategory.Soft },
                new Skill { Id = 22, Name = "Teamwork", Description = "Collaborative work and team building", Category = SkillCategory.Soft },
                new Skill { Id = 23, Name = "Time Management", Description = "Efficient time and task management", Category = SkillCategory.Soft },
                new Skill { Id = 24, Name = "Critical Thinking", Description = "Analytical and critical thinking", Category = SkillCategory.Soft },
                
                // Professional Skills
                new Skill { Id = 25, Name = "Project Management", Description = "Managing projects and resources", Category = SkillCategory.Professional },
                new Skill { Id = 26, Name = "Networking", Description = "Professional networking and relationship building", Category = SkillCategory.Professional },
                new Skill { Id = 27, Name = "Mentoring", Description = "Guiding and developing others", Category = SkillCategory.Professional },
                new Skill { Id = 28, Name = "Career Development", Description = "Career planning and advancement", Category = SkillCategory.Professional },
                new Skill { Id = 29, Name = "Research", Description = "Research methods and analysis", Category = SkillCategory.Professional },
                new Skill { Id = 30, Name = "Teaching", Description = "Educational instruction and training", Category = SkillCategory.Professional }
            };

            builder.Entity<Skill>().HasData(skills);
        }
    }
}
