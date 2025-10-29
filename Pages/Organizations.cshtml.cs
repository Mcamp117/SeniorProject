using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

[Authorize]
public class OrganizationsModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly IUserService _userService;

    public OrganizationsModel(IStudentOrganizationService organizationService, IUserService userService)
    {
        _organizationService = organizationService;
        _userService = userService;
    }

    public List<StudentOrganization> Organizations { get; set; } = new List<StudentOrganization>();
    public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    public async Task OnGetAsync()
    {
        Organizations = await _organizationService.GetActiveOrganizationsAsync();
        Users = await _userService.GetAllUsersAsync();
    }
}
