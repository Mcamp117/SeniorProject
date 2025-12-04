using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Organizations;

[Authorize]
public class ViewModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public ViewModel(
        IStudentOrganizationService organizationService,
        UserManager<ApplicationUser> userManager)
    {
        _organizationService = organizationService;
        _userManager = userManager;
    }

    public StudentOrganization Organization { get; set; } = null!;
    public List<OrganizationPost> Posts { get; set; } = new();
    public List<OrganizationMessage> Messages { get; set; } = new();
    public List<StudentOrganizationMember> Members { get; set; } = new();
    public ApplicationUser CurrentUser { get; set; } = null!;
    public bool IsMember { get; set; }
    public bool IsModerator { get; set; }
    public bool HasPendingRequest { get; set; }
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

        Organization = org;
        IsMember = await _organizationService.IsMemberAsync(id, CurrentUser.Id);
        IsModerator = await _organizationService.IsModeratorAsync(id, CurrentUser.Id);
        HasPendingRequest = await _organizationService.HasPendingRequestAsync(id, CurrentUser.Id);

        // Only load posts and messages if user is a member or moderator
        if (IsMember || IsModerator)
        {
            Posts = await _organizationService.GetOrganizationPostsAsync(id);
            Messages = await _organizationService.GetMessagesAsync(id, null, 100);
        }

        Members = Organization.Members.Where(m => m.IsActive).ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostRequestJoinAsync(int id, string? message)
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

        // Check if already a member
        if (await _organizationService.IsMemberAsync(id, CurrentUser.Id))
        {
            return RedirectToPage(new { id });
        }

        // Check if already has pending request
        if (await _organizationService.HasPendingRequestAsync(id, CurrentUser.Id))
        {
            ErrorMessage = "You already have a pending request for this organization.";
            Organization = org;
            IsMember = false;
            IsModerator = false;
            HasPendingRequest = true;
            Members = org.Members.Where(m => m.IsActive).ToList();
            return Page();
        }

        await _organizationService.CreateMembershipRequestAsync(id, CurrentUser.Id, message ?? "");
        return RedirectToPage(new { id });
    }
}

