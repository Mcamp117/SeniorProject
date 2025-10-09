using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class MentorshipModel : PageModel
{
    private readonly StaticDataService _dataService;

    public MentorshipModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<Relationship> Mentorships { get; set; } = new List<Relationship>();
    public List<User> AvailableMentors { get; set; } = new List<User>();

    public void OnGet()
    {
        Mentorships = _dataService.GetRelationshipsByType(RelationshipType.AlumniStudent);
        AvailableMentors = _dataService.GetUsersByType(UserType.Alumni);
    }
}
