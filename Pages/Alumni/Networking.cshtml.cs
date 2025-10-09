using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class NetworkingModel : PageModel
{
    private readonly StaticDataService _dataService;

    public NetworkingModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<User> Alumni { get; set; } = new List<User>();
    public List<string> Industries { get; set; } = new List<string>();
    public List<string> Companies { get; set; } = new List<string>();

    public void OnGet()
    {
        Alumni = _dataService.GetUsersByType(UserType.Alumni);
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
