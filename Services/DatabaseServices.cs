using Microsoft.EntityFrameworkCore;
using EagleConnect.Data;
using EagleConnect.Models;

namespace EagleConnect.Services
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkillsAsync();
        Task<Skill?> GetSkillByIdAsync(int id);
        Task<Skill?> GetSkillByNameAsync(string name);
        Task<List<Skill>> GetSkillsByCategoryAsync(SkillCategory category);
        Task<Skill> CreateSkillAsync(Skill skill);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task<bool> DeleteSkillAsync(int id);
    }

    public interface IStudentOrganizationService
    {
        Task<List<StudentOrganization>> GetAllOrganizationsAsync();
        Task<StudentOrganization?> GetOrganizationByIdAsync(int id);
        Task<List<StudentOrganization>> GetOrganizationsByCategoryAsync(string category);
        Task<List<StudentOrganization>> GetActiveOrganizationsAsync();
        Task<StudentOrganization> CreateOrganizationAsync(StudentOrganization organization);
        Task<StudentOrganization> UpdateOrganizationAsync(StudentOrganization organization);
        Task<bool> DeleteOrganizationAsync(int id);
        Task<bool> AddMemberToOrganizationAsync(int organizationId, string userId, string role = "Member");
        Task<bool> RemoveMemberFromOrganizationAsync(int organizationId, string userId);
        Task<List<ApplicationUser>> GetOrganizationMembersAsync(int organizationId);
    }

    public interface IRelationshipService
    {
        Task<List<Relationship>> GetAllRelationshipsAsync();
        Task<Relationship?> GetRelationshipByIdAsync(int id);
        Task<List<Relationship>> GetRelationshipsByTypeAsync(RelationshipType type);
        Task<List<Relationship>> GetMentorRelationshipsAsync(string mentorId);
        Task<List<Relationship>> GetMenteeRelationshipsAsync(string menteeId);
        Task<Relationship> CreateRelationshipAsync(Relationship relationship);
        Task<Relationship> UpdateRelationshipAsync(Relationship relationship);
        Task<bool> DeleteRelationshipAsync(int id);
        Task<bool> AcceptRelationshipAsync(int id);
        Task<bool> RejectRelationshipAsync(int id);
    }

    public interface IConnectionPostService
    {
        Task<List<ConnectionPost>> GetAllConnectionPostsAsync();
        Task<ConnectionPost?> GetConnectionPostByIdAsync(int id);
        Task<List<ConnectionPost>> GetActiveConnectionPostsAsync();
        Task<List<ConnectionPost>> GetConnectionPostsByTypeAsync(ConnectionType type);
        Task<List<ConnectionPost>> GetConnectionPostsBySeekingAsync(SeekingType seeking);
        Task<List<ConnectionPost>> GetConnectionPostsByPosterAsync(string posterId);
        Task<ConnectionPost> CreateConnectionPostAsync(ConnectionPost post);
        Task<ConnectionPost> UpdateConnectionPostAsync(ConnectionPost post);
        Task<bool> DeleteConnectionPostAsync(int id);
        Task<bool> CloseConnectionPostAsync(int id);
    }

    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetUserByIdAsync(string id);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
        Task<List<ApplicationUser>> GetUsersByTypeAsync(UserType type);
        Task<List<ApplicationUser>> GetUsersBySkillAsync(int skillId);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
        Task<bool> AddSkillToUserAsync(string userId, int skillId, string proficiencyLevel = "Beginner", string notes = "");
        Task<bool> RemoveSkillFromUserAsync(string userId, int skillId);
        Task<List<UserSkill>> GetUserSkillsAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
        Task<Dictionary<string, List<string>>> GetUserRolesAsync();
    }

    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext _context;

        public SkillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skills.OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<Skill?> GetSkillByNameAsync(string name)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<List<Skill>> GetSkillsByCategoryAsync(SkillCategory category)
        {
            return await _context.Skills.Where(s => s.Category == category).OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            skill.UpdatedAt = DateTime.UtcNow;
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public class StudentOrganizationService : IStudentOrganizationService
    {
        private readonly ApplicationDbContext _context;

        public StudentOrganizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentOrganization>> GetAllOrganizationsAsync()
        {
            return await _context.StudentOrganizations
                .Include(o => o.Members)
                .ThenInclude(m => m.User)
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<StudentOrganization?> GetOrganizationByIdAsync(int id)
        {
            return await _context.StudentOrganizations
                .Include(o => o.Members)
                .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<StudentOrganization>> GetOrganizationsByCategoryAsync(string category)
        {
            return await _context.StudentOrganizations
                .Include(o => o.Members)
                .ThenInclude(m => m.User)
                .Where(o => o.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<List<StudentOrganization>> GetActiveOrganizationsAsync()
        {
            return await _context.StudentOrganizations
                .Include(o => o.Members)
                .ThenInclude(m => m.User)
                .Where(o => o.IsActive)
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<StudentOrganization> CreateOrganizationAsync(StudentOrganization organization)
        {
            _context.StudentOrganizations.Add(organization);
            await _context.SaveChangesAsync();
            return organization;
        }

        public async Task<StudentOrganization> UpdateOrganizationAsync(StudentOrganization organization)
        {
            _context.StudentOrganizations.Update(organization);
            await _context.SaveChangesAsync();
            return organization;
        }

        public async Task<bool> DeleteOrganizationAsync(int id)
        {
            var organization = await _context.StudentOrganizations.FindAsync(id);
            if (organization == null) return false;

            _context.StudentOrganizations.Remove(organization);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMemberToOrganizationAsync(int organizationId, string userId, string role = "Member")
        {
            var existingMember = await _context.StudentOrganizationMembers
                .FirstOrDefaultAsync(m => m.OrganizationId == organizationId && m.UserId == userId);

            if (existingMember != null)
            {
                existingMember.IsActive = true;
                existingMember.Role = role;
            }
            else
            {
                var member = new StudentOrganizationMember
                {
                    OrganizationId = organizationId,
                    UserId = userId,
                    Role = role,
                    JoinedDate = DateTime.UtcNow,
                    IsActive = true
                };
                _context.StudentOrganizationMembers.Add(member);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveMemberFromOrganizationAsync(int organizationId, string userId)
        {
            var member = await _context.StudentOrganizationMembers
                .FirstOrDefaultAsync(m => m.OrganizationId == organizationId && m.UserId == userId);

            if (member == null) return false;

            member.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ApplicationUser>> GetOrganizationMembersAsync(int organizationId)
        {
            return await _context.StudentOrganizationMembers
                .Where(m => m.OrganizationId == organizationId && m.IsActive)
                .Include(m => m.User)
                .Select(m => m.User!)
                .ToListAsync();
        }
    }

    public class RelationshipService : IRelationshipService
    {
        private readonly ApplicationDbContext _context;

        public RelationshipService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Relationship>> GetAllRelationshipsAsync()
        {
            return await _context.Relationships
                .Include(r => r.Mentor)
                .Include(r => r.Mentee)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }

        public async Task<Relationship?> GetRelationshipByIdAsync(int id)
        {
            return await _context.Relationships
                .Include(r => r.Mentor)
                .Include(r => r.Mentee)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Relationship>> GetRelationshipsByTypeAsync(RelationshipType type)
        {
            return await _context.Relationships
                .Include(r => r.Mentor)
                .Include(r => r.Mentee)
                .Where(r => r.Type == type)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<Relationship>> GetMentorRelationshipsAsync(string mentorId)
        {
            return await _context.Relationships
                .Include(r => r.Mentor)
                .Include(r => r.Mentee)
                .Where(r => r.MentorId == mentorId)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<Relationship>> GetMenteeRelationshipsAsync(string menteeId)
        {
            return await _context.Relationships
                .Include(r => r.Mentor)
                .Include(r => r.Mentee)
                .Where(r => r.MenteeId == menteeId)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
        }

        public async Task<Relationship> CreateRelationshipAsync(Relationship relationship)
        {
            _context.Relationships.Add(relationship);
            await _context.SaveChangesAsync();
            return relationship;
        }

        public async Task<Relationship> UpdateRelationshipAsync(Relationship relationship)
        {
            _context.Relationships.Update(relationship);
            await _context.SaveChangesAsync();
            return relationship;
        }

        public async Task<bool> DeleteRelationshipAsync(int id)
        {
            var relationship = await _context.Relationships.FindAsync(id);
            if (relationship == null) return false;

            _context.Relationships.Remove(relationship);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AcceptRelationshipAsync(int id)
        {
            var relationship = await _context.Relationships.FindAsync(id);
            if (relationship == null) return false;

            relationship.Status = "Active";
            relationship.StartedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectRelationshipAsync(int id)
        {
            var relationship = await _context.Relationships.FindAsync(id);
            if (relationship == null) return false;

            relationship.Status = "Rejected";
            relationship.EndedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public class ConnectionPostService : IConnectionPostService
    {
        private readonly ApplicationDbContext _context;

        public ConnectionPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConnectionPost>> GetAllConnectionPostsAsync()
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .OrderByDescending(cp => cp.PostedDate)
                .ToListAsync();
        }

        public async Task<ConnectionPost?> GetConnectionPostByIdAsync(int id)
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .FirstOrDefaultAsync(cp => cp.Id == id);
        }

        public async Task<List<ConnectionPost>> GetActiveConnectionPostsAsync()
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .Where(cp => cp.Status == PostStatus.Active)
                .OrderByDescending(cp => cp.PostedDate)
                .ToListAsync();
        }

        public async Task<List<ConnectionPost>> GetConnectionPostsByTypeAsync(ConnectionType type)
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .Where(cp => cp.Type == type)
                .OrderByDescending(cp => cp.PostedDate)
                .ToListAsync();
        }

        public async Task<List<ConnectionPost>> GetConnectionPostsBySeekingAsync(SeekingType seeking)
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .Where(cp => cp.Seeking == seeking)
                .OrderByDescending(cp => cp.PostedDate)
                .ToListAsync();
        }

        public async Task<List<ConnectionPost>> GetConnectionPostsByPosterAsync(string posterId)
        {
            return await _context.ConnectionPosts
                .Include(cp => cp.Poster)
                .Where(cp => cp.PosterId == posterId)
                .OrderByDescending(cp => cp.PostedDate)
                .ToListAsync();
        }

        public async Task<ConnectionPost> CreateConnectionPostAsync(ConnectionPost post)
        {
            _context.ConnectionPosts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<ConnectionPost> UpdateConnectionPostAsync(ConnectionPost post)
        {
            post.UpdatedAt = DateTime.UtcNow;
            _context.ConnectionPosts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeleteConnectionPostAsync(int id)
        {
            var post = await _context.ConnectionPosts.FindAsync(id);
            if (post == null) return false;

            _context.ConnectionPosts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CloseConnectionPostAsync(int id)
        {
            var post = await _context.ConnectionPosts.FindAsync(id);
            if (post == null) return false;

            post.Status = PostStatus.Closed;
            post.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string id)
        {
            return await _context.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<ApplicationUser>> GetUsersByTypeAsync(UserType type)
        {
            return await _context.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .Where(u => u.Type == type)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetUsersBySkillAsync(int skillId)
        {
            return await _context.UserSkills
                .Where(us => us.SkillId == skillId)
                .Include(us => us.User)
                .Select(us => us.User!)
                .ToListAsync();
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> AddSkillToUserAsync(string userId, int skillId, string proficiencyLevel = "Beginner", string notes = "")
        {
            var existingUserSkill = await _context.UserSkills
                .FirstOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillId);

            if (existingUserSkill != null)
            {
                existingUserSkill.ProficiencyLevel = proficiencyLevel;
                existingUserSkill.Notes = notes;
                existingUserSkill.AcquiredDate = DateTime.UtcNow;
            }
            else
            {
                var userSkill = new UserSkill
                {
                    UserId = userId,
                    SkillId = skillId,
                    ProficiencyLevel = proficiencyLevel,
                    Notes = notes,
                    AcquiredDate = DateTime.UtcNow
                };
                _context.UserSkills.Add(userSkill);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveSkillFromUserAsync(string userId, int skillId)
        {
            var userSkill = await _context.UserSkills
                .FirstOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillId);

            if (userSkill == null) return false;

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserSkill>> GetUserSkillsAsync(string userId)
        {
            return await _context.UserSkills
                .Where(us => us.UserId == userId)
                .Include(us => us.Skill)
                .OrderBy(us => us.Skill!.Name)
                .ToListAsync();
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, List<string>>> GetUserRolesAsync()
        {
            var userRoles = new Dictionary<string, List<string>>();
            
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                var roles = await _context.UserRoles
                    .Where(ur => ur.UserId == user.Id)
                    .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                    .ToListAsync();
                
                userRoles[user.Id] = roles;
            }
            
            return userRoles;
        }
    }
}
