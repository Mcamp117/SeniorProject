using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;

namespace EagleConnect.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly StaticDataService _dataService;

    public IndexModel(ILogger<IndexModel> logger, StaticDataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public List<Models.ConnectionPost> ActiveConnectionPosts { get; set; } = new List<Models.ConnectionPost>();
    public int TotalUsers { get; set; }
    public int TotalAlumni { get; set; }
    public int TotalStudents { get; set; }
    public int TotalOrganizations { get; set; }
    public int ActiveRelationships { get; set; }

    public void OnGet()
    {
        ActiveConnectionPosts = _dataService.GetActiveConnectionPosts();
        TotalUsers = _dataService.Users.Count;
        TotalAlumni = _dataService.Users.Count(u => u.Type == Models.UserType.Alumni);
        TotalStudents = _dataService.Users.Count(u => u.Type == Models.UserType.Student);
        TotalOrganizations = _dataService.Organizations.Count;
        ActiveRelationships = _dataService.Relationships.Count(r => r.Status == "Active");
    }
}
