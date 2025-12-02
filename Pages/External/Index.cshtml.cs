using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IRelationshipService _relationshipService;
    private readonly IConnectionPostService _postService;
    private readonly AuthService _authService;
    private readonly IConnectionService _connectionService;

    public IndexModel(
        IUserService userService, 
        IRelationshipService relationshipService,
        IConnectionPostService postService,
        AuthService authService,
        IConnectionService connectionService)
    {
        _userService = userService;
        _relationshipService = relationshipService;
        _postService = postService;
        _authService = authService;
        _connectionService = connectionService;
    }

    public List<ApplicationUser> ExternalMentors { get; set; } = new List<ApplicationUser>();
    public List<Relationship> ExternalMentorships { get; set; } = new List<Relationship>();
    public List<ConnectionPost> MentorshipPosts { get; set; } = new List<ConnectionPost>();
    public ApplicationUser? CurrentUser { get; set; }
    public Dictionary<string, bool> ConnectionStatuses { get; set; } = new();

    public async Task OnGetAsync()
    {
        ExternalMentors = await _userService.GetUsersByTypeAsync(UserType.External);
        ExternalMentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.ExternalStudent);
        
        // Get all posts and filter for mentorship posts from External only
        var allPosts = await _postService.GetAllConnectionPostsAsync();
        MentorshipPosts = allPosts
            .Where(p => p.Type == ConnectionType.Mentorship && 
                       p.Status == PostStatus.Active &&
                       p.Poster?.Type == UserType.External)
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
