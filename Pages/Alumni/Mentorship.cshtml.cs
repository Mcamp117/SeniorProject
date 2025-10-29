using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

public class MentorshipModel : PageModel
{
    private readonly IRelationshipService _relationshipService;
    private readonly IUserService _userService;

    public MentorshipModel(IRelationshipService relationshipService, IUserService userService)
    {
        _relationshipService = relationshipService;
        _userService = userService;
    }

    public List<Relationship> Mentorships { get; set; } = new List<Relationship>();
    public List<ApplicationUser> AvailableMentors { get; set; } = new List<ApplicationUser>();

    public async Task OnGetAsync()
    {
        Mentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.AlumniStudent);
        AvailableMentors = await _userService.GetUsersByTypeAsync(UserType.Alumni);
    }
}
