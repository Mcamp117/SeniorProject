using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Posts;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IConnectionPostService _postService;
    private readonly IConnectionService _connectionService;
    private readonly IUserService _userService;

    public IndexModel(IConnectionPostService postService, IConnectionService connectionService, IUserService userService)
    {
        _postService = postService;
        _connectionService = connectionService;
        _userService = userService;
    }

    public IList<ConnectionPost> AllPosts { get; set; } = new List<ConnectionPost>();
    public ApplicationUser? CurrentUser { get; set; }
    public Dictionary<string, bool> ConnectionStatuses { get; set; } = new();

    public async Task OnGetAsync()
    {
        AllPosts = await _postService.GetAllConnectionPostsAsync();
        
        if (User.Identity?.Name != null)
        {
            CurrentUser = await _userService.GetUserByEmailAsync(User.Identity.Name);
            
            if (CurrentUser != null)
            {
                foreach (var post in AllPosts)
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
}
