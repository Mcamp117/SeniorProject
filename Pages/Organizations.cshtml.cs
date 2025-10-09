using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

public class OrganizationsModel : PageModel
{
    private readonly StaticDataService _dataService;

    public OrganizationsModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<StudentOrganization> Organizations { get; set; } = new List<StudentOrganization>();
    public List<User> Users { get; set; } = new List<User>();

    public void OnGet()
    {
        Organizations = _dataService.Organizations;
        Users = _dataService.Users;
    }
}
