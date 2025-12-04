using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Organizations;

[Authorize]
public class ManageModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public ManageModel(
        IStudentOrganizationService organizationService,
        UserManager<ApplicationUser> userManager)
    {
        _organizationService = organizationService;
        _userManager = userManager;
    }

    public StudentOrganization Organization { get; set; } = null!;
    public List<OrganizationMembershipRequest> PendingRequests { get; set; } = new();
    public List<StudentOrganizationMember> Members { get; set; } = new();
    public List<OrganizationPost> Posts { get; set; } = new();
    public ApplicationUser CurrentUser { get; set; } = null!;
    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        // Only moderator or admin can access this page
        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        Organization = org;
        PendingRequests = await _organizationService.GetPendingRequestsAsync(id);
        Members = org.Members.Where(m => m.IsActive).ToList();
        Posts = await _organizationService.GetOrganizationPostsAsync(id);

        return Page();
    }

    public async Task<IActionResult> OnPostApproveRequestAsync(int id, int requestId)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        var result = await _organizationService.ApproveMembershipRequestAsync(requestId, CurrentUser.Id);
        if (result)
        {
            TempData["SuccessMessage"] = "Membership request approved successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to approve membership request.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostRejectRequestAsync(int id, int requestId, string? reason)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        var result = await _organizationService.RejectMembershipRequestAsync(requestId, CurrentUser.Id, reason);
        if (result)
        {
            TempData["SuccessMessage"] = "Membership request rejected.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to reject membership request.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostRemoveMemberAsync(int id, string userId)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        // Cannot remove moderator
        if (org.ModeratorId == userId)
        {
            TempData["ErrorMessage"] = "Cannot remove the moderator from the organization.";
            return RedirectToPage(new { id });
        }

        var result = await _organizationService.RemoveMemberFromOrganizationAsync(id, userId);
        if (result)
        {
            TempData["SuccessMessage"] = "Member removed successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to remove member.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostDeletePostAsync(int id, int postId)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        var result = await _organizationService.DeletePostAsync(postId);
        if (result)
        {
            TempData["SuccessMessage"] = "Post deleted successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to delete post.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostTogglePinAsync(int id, int postId)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        await _organizationService.TogglePinPostAsync(postId);
        return RedirectToPage(new { id });
    }
}

