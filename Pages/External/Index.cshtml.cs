using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IRelationshipService _relationshipService;

    public IndexModel(IUserService userService, IRelationshipService relationshipService)
    {
        _userService = userService;
        _relationshipService = relationshipService;
    }

    public List<ApplicationUser> ExternalMentors { get; set; } = new List<ApplicationUser>();
    public List<Relationship> ExternalMentorships { get; set; } = new List<Relationship>();

    public async Task OnGetAsync()
    {
        ExternalMentors = await _userService.GetUsersByTypeAsync(UserType.External);
        ExternalMentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.ExternalStudent);
    }
}
