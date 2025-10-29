using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ISkillService _skillService;
    private readonly IStudentOrganizationService _organizationService;
    private readonly IRelationshipService _relationshipService;
    private readonly IConnectionPostService _postService;
    private readonly IUserService _userService;

    public IndexModel(ISkillService skillService, IStudentOrganizationService organizationService,
        IRelationshipService relationshipService, IConnectionPostService postService, IUserService userService)
    {
        _skillService = skillService;
        _organizationService = organizationService;
        _relationshipService = relationshipService;
        _postService = postService;
        _userService = userService;
    }

    public int TotalSkills { get; set; }
    public int TotalOrganizations { get; set; }
    public int ActiveOrganizations { get; set; }
    public int TotalRelationships { get; set; }
    public int ActiveRelationships { get; set; }
    public int TotalPosts { get; set; }
    public int ActivePosts { get; set; }
    public int TotalUsers { get; set; }
    public int TotalStudents { get; set; }
    public int TotalAlumni { get; set; }

    public async Task OnGetAsync()
    {
        var skills = await _skillService.GetAllSkillsAsync();
        TotalSkills = skills.Count;

        var organizations = await _organizationService.GetAllOrganizationsAsync();
        TotalOrganizations = organizations.Count;
        ActiveOrganizations = organizations.Count(o => o.IsActive);

        var relationships = await _relationshipService.GetAllRelationshipsAsync();
        TotalRelationships = relationships.Count;
        ActiveRelationships = relationships.Count(r => r.Status == "Active");

        var posts = await _postService.GetAllConnectionPostsAsync();
        TotalPosts = posts.Count;
        ActivePosts = posts.Count(p => p.Status == PostStatus.Active);

        var users = await _userService.GetAllUsersAsync();
        TotalUsers = users.Count;
        TotalStudents = users.Count(u => u.Type == UserType.Student);
        TotalAlumni = users.Count(u => u.Type == UserType.Alumni);
    }
}

