using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Posts;

[Authorize]
public class CreateModel : PageModel
{
    private readonly IConnectionPostService _postService;
    private readonly IUserService _userService;

    public CreateModel(IConnectionPostService postService, IUserService userService)
    {
        _postService = postService;
        _userService = userService;
    }

    [BindProperty]
    public ConnectionPost Post { get; set; } = new ConnectionPost();

    public async Task OnGetAsync()
    {
        Post.PostedDate = DateTime.UtcNow;
        Post.Status = PostStatus.Active;
        
        // Get current user to set as poster
        var currentUser = await _userService.GetUserByEmailAsync(User.Identity?.Name ?? "");
        if (currentUser != null)
        {
            Post.PosterId = currentUser.Id;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Verify the PosterId is set (it should be from OnGetAsync)
        if (string.IsNullOrEmpty(Post.PosterId))
        {
            ModelState.AddModelError("", "Unable to identify current user. Please try again.");
            return Page();
        }

        Post.PostedDate = DateTime.UtcNow;
        Post.UpdatedAt = DateTime.UtcNow;
        
        try
        {
            var createdPost = await _postService.CreateConnectionPostAsync(Post);
            // Log success for debugging
            Console.WriteLine($"Post created successfully with ID: {createdPost.Id}");
            return Redirect("/home");
        }
        catch (Exception ex)
        {
            // Log error for debugging
            Console.WriteLine($"Error creating post: {ex.Message}");
            ModelState.AddModelError("", $"Error creating post: {ex.Message}");
            return Page();
        }
    }
}
