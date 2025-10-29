using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Posts;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IConnectionPostService _postService;
    private readonly IUserService _userService;

    public EditModel(IConnectionPostService postService, IUserService userService)
    {
        _postService = postService;
        _userService = userService;
    }

    [BindProperty]
    public ConnectionPost Item { get; set; } = new ConnectionPost();

    public IList<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var p = await _postService.GetConnectionPostByIdAsync(id);
        if (p == null) return NotFound();
        Item = p;
        Users = await _userService.GetAllUsersAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Users = await _userService.GetAllUsersAsync();
            return Page();
        }

        Item.UpdatedAt = DateTime.UtcNow;
        await _postService.UpdateConnectionPostAsync(Item);
        return RedirectToPage("./Index");
    }
}

