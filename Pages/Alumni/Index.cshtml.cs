using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class IndexModel : PageModel
{
    private readonly StaticDataService _dataService;

    public IndexModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<User> Alumni { get; set; } = new List<User>();
    public List<Relationship> ActiveMentorships { get; set; } = new List<Relationship>();

    public void OnGet()
    {
        Alumni = _dataService.GetUsersByType(UserType.Alumni);
        ActiveMentorships = _dataService.GetRelationshipsByType(RelationshipType.AlumniStudent)
            .Where(r => r.Status == "Active").ToList();
    }
}
