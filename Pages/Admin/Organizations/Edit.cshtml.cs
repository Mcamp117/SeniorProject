using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Organizations;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly IUserService _userService;

    public EditModel(IStudentOrganizationService organizationService, IUserService userService)
    {
        _organizationService = organizationService;
        _userService = userService;
    }

    [BindProperty]
    public StudentOrganization Organization { get; set; } = null!;

    [BindProperty]
    public string? SelectedModeratorId { get; set; }

    public SelectList UserList { get; set; } = null!;
    public string? CurrentModeratorName { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        Organization = org;
        SelectedModeratorId = org.ModeratorId;
        CurrentModeratorName = org.Moderator != null ? $"{org.Moderator.FirstName} {org.Moderator.LastName}" : null;

        var users = await _userService.GetAllUsersAsync();
        UserList = new SelectList(
            users.Where(u => u.IsApproved).Select(u => new { u.Id, Name = $"{u.FirstName} {u.LastName} ({u.Email})" }),
            "Id",
            "Name",
            SelectedModeratorId
        );

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var existingOrg = await _organizationService.GetOrganizationByIdAsync(id);
        if (existingOrg == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            var users = await _userService.GetAllUsersAsync();
            UserList = new SelectList(
                users.Where(u => u.IsApproved).Select(u => new { u.Id, Name = $"{u.FirstName} {u.LastName} ({u.Email})" }),
                "Id",
                "Name",
                SelectedModeratorId
            );
            return Page();
        }

        // Track if moderator changed
        var oldModeratorId = existingOrg.ModeratorId;
        var newModeratorId = SelectedModeratorId;

        // Update organization properties
        existingOrg.Name = Organization.Name;
        existingOrg.Description = Organization.Description;
        existingOrg.Category = Organization.Category;
        existingOrg.ContactEmail = Organization.ContactEmail;
        existingOrg.Website = Organization.Website;
        existingOrg.MeetingSchedule = Organization.MeetingSchedule;
        existingOrg.Location = Organization.Location;
        existingOrg.IsActive = Organization.IsActive;
        existingOrg.ModeratorId = newModeratorId;

        await _organizationService.UpdateOrganizationAsync(existingOrg);

        // Handle moderator change - add new moderator as member
        if (newModeratorId != oldModeratorId && !string.IsNullOrEmpty(newModeratorId))
        {
            // Add new moderator as member if not already
            var isMember = await _organizationService.IsMemberAsync(id, newModeratorId);
            if (!isMember)
            {
                await _organizationService.AddMemberToOrganizationAsync(id, newModeratorId, "Moderator");
            }
        }

        TempData["SuccessMessage"] = "Organization updated successfully.";
        return RedirectToPage("./Index");
    }
}

