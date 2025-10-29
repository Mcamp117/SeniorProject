using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Posts;

[Authorize]
public class MyPostsModel : PageModel
{
    private readonly IConnectionPostService _postService;
    private readonly IUserService _userService;

    public MyPostsModel(IConnectionPostService postService, IUserService userService)
    {
        _postService = postService;
        _userService = userService;
    }

    public IList<ConnectionPost> MyPosts { get; set; } = new List<ConnectionPost>();

    public async Task OnGetAsync()
    {
        var currentUser = await _userService.GetUserByEmailAsync(User.Identity?.Name ?? "");
        if (currentUser != null)
        {
            MyPosts = await _postService.GetConnectionPostsByPosterAsync(currentUser.Id);
        }
    }

    public async Task<IActionResult> OnPostCloseAsync(int id)
    {
        await _postService.CloseConnectionPostAsync(id);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _postService.DeleteConnectionPostAsync(id);
        return RedirectToPage();
    }
}
