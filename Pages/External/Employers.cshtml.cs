using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

public class EmployersModel : PageModel
{
    private readonly StaticDataService _dataService;

    public EmployersModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<User> Employers { get; set; } = new List<User>();
    public List<string> Companies { get; set; } = new List<string>();

    public void OnGet()
    {
        Employers = _dataService.GetUsersByType(UserType.External);
        Companies = Employers.Select(e => e.Company).Distinct().ToList();
    }
}
