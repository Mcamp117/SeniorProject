using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

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

    public List<ApplicationUser> Alumni { get; set; } = new List<ApplicationUser>();
    public List<Relationship> ActiveMentorships { get; set; } = new List<Relationship>();

    public async Task OnGetAsync()
    {
        Alumni = await _userService.GetUsersByTypeAsync(UserType.Alumni);
        var allMentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.AlumniStudent);
        ActiveMentorships = allMentorships.Where(r => r.Status == "Active").ToList();
    }
}
