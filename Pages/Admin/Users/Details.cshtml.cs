using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class DetailsModel : PageModel
{
    private readonly IUserService _userService;
    private readonly UserManager<ApplicationUser> _userManager;

    public DetailsModel(IUserService userService, UserManager<ApplicationUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public ApplicationUser UserModel { get; set; } = new();
    public List<string> UserRoles { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        UserModel = await _userService.GetUserByIdAsync(id);
        if (UserModel == null)
        {
            return NotFound();
        }

        // Load user roles
        UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();

        return Page();
    }
}
