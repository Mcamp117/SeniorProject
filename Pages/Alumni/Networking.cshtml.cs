using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class NetworkingModel : PageModel
{
    private readonly IUserService _userService;

    public NetworkingModel(IUserService userService)
    {
        _userService = userService;
    }

    public List<ApplicationUser> Alumni { get; set; } = new List<ApplicationUser>();
    public List<string> Industries { get; set; } = new List<string>();
    public List<string> Companies { get; set; } = new List<string>();

    public async Task OnGetAsync()
    {
        Alumni = await _userService.GetUsersByTypeAsync(UserType.Alumni);
        Industries = Alumni.Select(a => GetIndustryFromCompany(a.Company)).Distinct().ToList();
        Companies = Alumni.Select(a => a.Company).Distinct().ToList();
    }

    private string GetIndustryFromCompany(string company)
    {
        return company.ToLower() switch
        {
            var c when c.Contains("microsoft") || c.Contains("tech") => "Technology",
            var c when c.Contains("procter") || c.Contains("gamble") => "Consumer Goods",
            var c when c.Contains("hospital") || c.Contains("medical") => "Healthcare",
            _ => "Other"
        };
    }
}
