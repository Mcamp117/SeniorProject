using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

[Authorize]
public class OrganizationsModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrganizationsModel(IStudentOrganizationService organizationService, UserManager<ApplicationUser> userManager)
    {
        _organizationService = organizationService;
        _userManager = userManager;
    }

    public List<StudentOrganization> Organizations { get; set; } = new List<StudentOrganization>();
    public List<StudentOrganization> MyOrganizations { get; set; } = new List<StudentOrganization>();
    public ApplicationUser CurrentUser { get; set; } = null!;
    public Dictionary<int, bool> IsMemberOf { get; set; } = new();
    public Dictionary<int, bool> HasPendingRequest { get; set; } = new();

    public async Task OnGetAsync()
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        Organizations = await _organizationService.GetActiveOrganizationsAsync();
        
        if (CurrentUser != null)
        {
            MyOrganizations = await _organizationService.GetUserOrganizationsAsync(CurrentUser.Id);
            
            foreach (var org in Organizations)
            {
                IsMemberOf[org.Id] = await _organizationService.IsMemberAsync(org.Id, CurrentUser.Id) 
                                     || org.ModeratorId == CurrentUser.Id;
                HasPendingRequest[org.Id] = await _organizationService.HasPendingRequestAsync(org.Id, CurrentUser.Id);
            }
        }
    }
}
