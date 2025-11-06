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

    public async Task<IActionResult> OnGetAsync(string? type = null)
    {
        // Get current user to set as poster
        var currentUser = await _userService.GetUserByEmailAsync(User.Identity?.Name ?? "");
        if (currentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        Post.PostedDate = DateTime.UtcNow;
        Post.Status = PostStatus.Active;
        
        // Pre-fill type if provided
        if (!string.IsNullOrEmpty(type) && Enum.TryParse<ConnectionType>(type, out var connectionType))
        {
            // Alumni, Faculty, and External can create mentorship posts
            if (connectionType == ConnectionType.Mentorship && 
                currentUser.Type != UserType.Alumni && 
                currentUser.Type != UserType.Faculty && 
                currentUser.Type != UserType.External)
            {
                return RedirectToPage("/Alumni/Mentorship");
            }
            Post.Type = connectionType;
        }
        
        Post.PosterId = currentUser.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Get current user
        var currentUser = await _userService.GetUserByEmailAsync(User.Identity?.Name ?? "");
        if (currentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        // Only Alumni, Faculty, and External can create mentorship posts
        if (Post.Type == ConnectionType.Mentorship && 
            currentUser.Type != UserType.Alumni && 
            currentUser.Type != UserType.Faculty && 
            currentUser.Type != UserType.External)
        {
            ModelState.AddModelError("", "Only Alumni, Faculty, and External mentors can create mentorship posts.");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Verify the PosterId is set (it should be from OnGetAsync)
        if (string.IsNullOrEmpty(Post.PosterId))
        {
            Post.PosterId = currentUser.Id;
        }
        
        // Ensure the poster is the current user
        if (Post.PosterId != currentUser.Id)
        {
            ModelState.AddModelError("", "You can only create posts for yourself.");
            return Page();
        }

        Post.PostedDate = DateTime.UtcNow;
        Post.UpdatedAt = DateTime.UtcNow;
        
        try
        {
            var createdPost = await _postService.CreateConnectionPostAsync(Post);
            // Log success for debugging
            Console.WriteLine($"Post created successfully with ID: {createdPost.Id}");
            
            // Redirect based on post type and poster type
            if (createdPost.Type == ConnectionType.Mentorship)
            {
                if (currentUser.Type == UserType.Alumni)
                {
                    return Redirect("/Alumni/Mentorship");
                }
                else if (currentUser.Type == UserType.External)
                {
                    return Redirect("/External");
                }
                // Faculty can go to Posts page
                return Redirect("/Posts");
            }
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

