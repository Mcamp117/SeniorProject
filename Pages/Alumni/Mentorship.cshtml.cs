using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class MentorshipModel : PageModel
{
    private readonly IRelationshipService _relationshipService;
    private readonly IUserService _userService;
    private readonly IConnectionPostService _postService;
    private readonly AuthService _authService;
    private readonly IConnectionService _connectionService;

    public MentorshipModel(
        IRelationshipService relationshipService, 
        IUserService userService,
        IConnectionPostService postService,
        AuthService authService,
        IConnectionService connectionService)
    {
        _relationshipService = relationshipService;
        _userService = userService;
        _postService = postService;
        _authService = authService;
        _connectionService = connectionService;
    }

    public List<Relationship> Mentorships { get; set; } = new List<Relationship>();
    public List<ApplicationUser> AvailableMentors { get; set; } = new List<ApplicationUser>();
    public List<ConnectionPost> MentorshipPosts { get; set; } = new List<ConnectionPost>();
    public ApplicationUser? CurrentUser { get; set; }
    public Dictionary<string, bool> ConnectionStatuses { get; set; } = new();

    public async Task OnGetAsync()
    {
        Mentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.AlumniStudent);
        AvailableMentors = await _userService.GetUsersByTypeAsync(UserType.Alumni);
        
        // Get all posts and filter for mentorship posts from Alumni only
        var allPosts = await _postService.GetAllConnectionPostsAsync();
        MentorshipPosts = allPosts
            .Where(p => p.Type == ConnectionType.Mentorship && 
                       p.Status == PostStatus.Active &&
                       p.Poster?.Type == UserType.Alumni)
            .OrderByDescending(p => p.PostedDate)
            .ToList();

        // Get current user and check connection statuses
        if (User.Identity?.IsAuthenticated == true)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            
            if (CurrentUser != null)
            {
                foreach (var post in MentorshipPosts)
                {
                    if (post.PosterId != CurrentUser.Id)
                    {
                        ConnectionStatuses[post.PosterId] = await _connectionService.AreConnectedAsync(CurrentUser.Id, post.PosterId);
                    }
                }
            }
        }
    }

    public async Task<int?> GetConnectionIdAsync(string otherUserId)
    {
        if (CurrentUser == null) return null;
        var connection = await _connectionService.GetConnectionAsync(CurrentUser.Id, otherUserId);
        return connection?.Id;
    }

    public bool CanCreateMentorshipPost()
    {
        return CurrentUser?.Type == UserType.Alumni || 
               CurrentUser?.Type == UserType.Faculty || 
               CurrentUser?.Type == UserType.External;
    }
}
