using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

public class IndexModel : PageModel
{
    private readonly StaticDataService _dataService;

    public IndexModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<User> ExternalMentors { get; set; } = new List<User>();
    public List<Relationship> ExternalMentorships { get; set; } = new List<Relationship>();

    public void OnGet()
    {
        ExternalMentors = _dataService.GetUsersByType(UserType.External);
        ExternalMentorships = _dataService.GetRelationshipsByType(RelationshipType.ExternalStudent);
    }
}
