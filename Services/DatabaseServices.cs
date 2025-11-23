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

    public interface IConnectionService
    {
        Task<Connection?> GetConnectionAsync(string user1Id, string user2Id);
        Task<Connection?> GetConnectionByIdAsync(int connectionId);
        Task<List<Connection>> GetUserConnectionsAsync(string userId);
        Task<List<Connection>> GetPendingConnectionsAsync(string userId);
        Task<Connection> CreateConnectionAsync(string requesterId, string recipientId);
        Task<bool> AcceptConnectionAsync(int connectionId, string userId);
        Task<bool> DeclineConnectionAsync(int connectionId, string userId);
        Task<bool> AreConnectedAsync(string user1Id, string user2Id);
        Task<bool> DeleteConnectionAsync(int connectionId);
    }

    public interface IMessageService
    {
        Task<Message> SendMessageAsync(int connectionId, string senderId, string content);
        Task<List<Message>> GetMessagesAsync(int connectionId, int? skip = null, int? take = null);
        Task<bool> MarkMessageAsReadAsync(int messageId, string userId);
        Task<int> GetUnreadMessageCountAsync(string userId);
        Task<List<Message>> GetUnreadMessagesAsync(string userId);
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
            // Load the existing user from the database to avoid concurrency issues
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with ID {user.Id} not found.");
            }

            // Update required properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.Email; // Keep username in sync with email
            existingUser.Type = user.Type;
            existingUser.GraduationYear = user.GraduationYear;
            
            // Update optional properties - use empty string if null/whitespace to avoid database null constraint errors
            existingUser.Bio = string.IsNullOrWhiteSpace(user.Bio) ? string.Empty : user.Bio;
            existingUser.Company = string.IsNullOrWhiteSpace(user.Company) ? string.Empty : user.Company;
            existingUser.JobTitle = string.IsNullOrWhiteSpace(user.JobTitle) ? string.Empty : user.JobTitle;
            existingUser.ProfileImage = string.IsNullOrWhiteSpace(user.ProfileImage) ? "/images/default-avatar.svg" : user.ProfileImage;

            await _context.SaveChangesAsync();
            return existingUser;
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
                    .Where(name => name != null)
                    .Select(name => name!)
                    .ToListAsync();
                
                userRoles[user.Id] = roles;
            }
            
            return userRoles;
        }
    }

    public class ConnectionService : IConnectionService
    {
        private readonly ApplicationDbContext _context;

        public ConnectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Connection?> GetConnectionAsync(string user1Id, string user2Id)
        {
            // Check both directions since connection can be stored as User1-User2 or User2-User1
            var connection = await _context.Connections
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.RequestedBy)
                .Include(c => c.Messages.OrderByDescending(m => m.SentAt).Take(1))
                .FirstOrDefaultAsync(c => 
                    (c.User1Id == user1Id && c.User2Id == user2Id) ||
                    (c.User1Id == user2Id && c.User2Id == user1Id));
            
            return connection;
        }

        public async Task<Connection?> GetConnectionByIdAsync(int connectionId)
        {
            return await _context.Connections
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.RequestedBy)
                .Include(c => c.Messages.OrderByDescending(m => m.SentAt))
                .FirstOrDefaultAsync(c => c.Id == connectionId);
        }

        public async Task<List<Connection>> GetUserConnectionsAsync(string userId)
        {
            var connections = await _context.Connections
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.RequestedBy)
                .Where(c => (c.User1Id == userId || c.User2Id == userId) && c.Status == ConnectionStatus.Accepted)
                .ToListAsync();

            // Load last message for each connection
            foreach (var connection in connections)
            {
                var lastMessage = await _context.Messages
                    .Where(m => m.ConnectionId == connection.Id)
                    .OrderByDescending(m => m.SentAt)
                    .FirstOrDefaultAsync();
                
                if (lastMessage != null)
                {
                    connection.Messages = new List<Message> { lastMessage };
                }
            }

            // Order by last message time or accepted time
            return connections.OrderByDescending(c => 
                c.Messages.Any() ? c.Messages.Max(m => m.SentAt) : c.AcceptedAt ?? c.CreatedAt).ToList();
        }

        public async Task<List<Connection>> GetPendingConnectionsAsync(string userId)
        {
            // Only return connections where the user is the recipient (not the requester)
            return await _context.Connections
                .Include(c => c.User1)
                .Include(c => c.User2)
                .Include(c => c.RequestedBy)
                .Where(c => (c.User1Id == userId || c.User2Id == userId) 
                    && c.Status == ConnectionStatus.Pending
                    && c.RequestedById != userId) // Exclude connections requested by this user
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Connection> CreateConnectionAsync(string requesterId, string recipientId)
        {
            // Check if connection already exists in either direction
            var existing = await GetConnectionAsync(requesterId, recipientId);
            if (existing != null)
            {
                return existing;
            }

            // Ensure user1Id < user2Id for consistency (for indexing)
            string user1Id, user2Id;
            if (string.Compare(requesterId, recipientId) < 0)
            {
                user1Id = requesterId;
                user2Id = recipientId;
            }
            else
            {
                user1Id = recipientId;
                user2Id = requesterId;
            }

            var connection = new Connection
            {
                User1Id = user1Id,
                User2Id = user2Id,
                RequestedById = requesterId, // Track who initiated the request
                Status = ConnectionStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Connections.Add(connection);
            await _context.SaveChangesAsync();
            return connection;
        }

        public async Task<bool> AcceptConnectionAsync(int connectionId, string userId)
        {
            var connection = await _context.Connections.FindAsync(connectionId);
            if (connection == null) return false;

            // Verify the user is part of the connection
            if (connection.User2Id != userId && connection.User1Id != userId)
            {
                return false;
            }

            // Prevent users from accepting their own requests
            if (connection.RequestedById == userId)
            {
                return false;
            }

            connection.Status = ConnectionStatus.Accepted;
            connection.AcceptedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeclineConnectionAsync(int connectionId, string userId)
        {
            var connection = await _context.Connections.FindAsync(connectionId);
            if (connection == null) return false;

            // Verify the user is the recipient
            if (connection.User2Id != userId && connection.User1Id != userId)
            {
                return false;
            }

            connection.Status = ConnectionStatus.Declined;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AreConnectedAsync(string user1Id, string user2Id)
        {
            var connection = await GetConnectionAsync(user1Id, user2Id);
            return connection != null && connection.Status == ConnectionStatus.Accepted;
        }

        public async Task<bool> DeleteConnectionAsync(int connectionId)
        {
            var connection = await _context.Connections.FindAsync(connectionId);
            if (connection == null) return false;

            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Message> SendMessageAsync(int connectionId, string senderId, string content)
        {
            var message = new Message
            {
                ConnectionId = connectionId,
                SenderId = senderId,
                Content = content,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Load sender for SignalR
            message.Sender = await _context.Users.FindAsync(senderId);
            return message;
        }

        public async Task<List<Message>> GetMessagesAsync(int connectionId, int? skip = null, int? take = null)
        {
            var query = _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ConnectionId == connectionId)
                .OrderByDescending(m => m.SentAt);

            if (skip.HasValue)
            {
                query = (IOrderedQueryable<Message>)query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = (IOrderedQueryable<Message>)query.Take(take.Value);
            }

            var messages = await query.ToListAsync();
            return messages.OrderBy(m => m.SentAt).ToList(); // Reverse to show oldest first
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId, string userId)
        {
            var message = await _context.Messages
                .Include(m => m.Connection)
                .FirstOrDefaultAsync(m => m.Id == messageId);

            if (message == null) return false;

            // Verify the user is part of the connection
            if (message.Connection?.User1Id != userId && message.Connection?.User2Id != userId)
            {
                return false;
            }

            // Only mark as read if the user is not the sender
            if (message.SenderId != userId && !message.IsRead)
            {
                message.IsRead = true;
                message.ReadAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<int> GetUnreadMessageCountAsync(string userId)
        {
            return await _context.Messages
                .Include(m => m.Connection)
                .Where(m => 
                    !m.IsRead &&
                    m.SenderId != userId &&
                    (m.Connection!.User1Id == userId || m.Connection.User2Id == userId))
                .CountAsync();
        }

        public async Task<List<Message>> GetUnreadMessagesAsync(string userId)
        {
            return await _context.Messages
                .Include(m => m.Connection)
                .Include(m => m.Sender)
                .Where(m => 
                    !m.IsRead &&
                    m.SenderId != userId &&
                    (m.Connection!.User1Id == userId || m.Connection.User2Id == userId))
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }
    }
}
