using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

public class EmployersModel : PageModel
{
    private readonly IUserService _userService;

    public EmployersModel(IUserService userService)
    {
        _userService = userService;
    }

    public List<ApplicationUser> Employers { get; set; } = new List<ApplicationUser>();
    public List<string> Companies { get; set; } = new List<string>();

    public async Task OnGetAsync()
    {
        Employers = await _userService.GetUsersByTypeAsync(UserType.External);
        Companies = Employers.Select(e => e.Company).Distinct().ToList();
    }
}
