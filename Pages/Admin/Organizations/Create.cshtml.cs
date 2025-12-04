using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Organizations;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly IUserService _userService;

    public CreateModel(IStudentOrganizationService organizationService, IUserService userService)
    {
        _organizationService = organizationService;
        _userService = userService;
    }

    [BindProperty]
    public StudentOrganization Organization { get; set; } = new StudentOrganization();

    [BindProperty]
    public string? SelectedModeratorId { get; set; }

    public SelectList UserList { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        Organization.CreatedDate = DateTime.UtcNow;
        Organization.IsActive = true;
        
        var users = await _userService.GetAllUsersAsync();
        UserList = new SelectList(
            users.Where(u => u.IsApproved).Select(u => new { u.Id, Name = $"{u.FirstName} {u.LastName} ({u.Email})" }),
            "Id",
            "Name"
        );
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var users = await _userService.GetAllUsersAsync();
            UserList = new SelectList(
                users.Where(u => u.IsApproved).Select(u => new { u.Id, Name = $"{u.FirstName} {u.LastName} ({u.Email})" }),
                "Id",
                "Name"
            );
            return Page();
        }

        Organization.ModeratorId = SelectedModeratorId;
        await _organizationService.CreateOrganizationAsync(Organization);

        // If a moderator is assigned, also add them as a member
        if (!string.IsNullOrEmpty(SelectedModeratorId))
        {
            await _organizationService.AddMemberToOrganizationAsync(Organization.Id, SelectedModeratorId, "Moderator");
        }

        return RedirectToPage("./Index");
    }
}
