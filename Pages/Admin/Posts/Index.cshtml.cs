using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Posts;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IConnectionPostService _postService;
    private readonly IUserService _userService;

    public IndexModel(IConnectionPostService postService, IUserService userService)
    {
        _postService = postService;
        _userService = userService;
    }

    public IList<ConnectionPost> Items { get; set; } = new List<ConnectionPost>();

    public async Task OnGetAsync()
    {
        Items = await _postService.GetAllConnectionPostsAsync();
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

