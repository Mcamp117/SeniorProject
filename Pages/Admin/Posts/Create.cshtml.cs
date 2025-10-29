using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Posts;

[Authorize(Roles = "Admin")]
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
    public ConnectionPost Item { get; set; } = new ConnectionPost();

    public IList<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    public async Task OnGetAsync()
    {
        Users = await _userService.GetAllUsersAsync();
        Item.PostedDate = DateTime.UtcNow;
        Item.Status = PostStatus.Active;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Users = await _userService.GetAllUsersAsync();
            return Page();
        }

        Item.UpdatedAt = DateTime.UtcNow;
        await _postService.CreateConnectionPostAsync(Item);
        return RedirectToPage("./Index");
    }
}

