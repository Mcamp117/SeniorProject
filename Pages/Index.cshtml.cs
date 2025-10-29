using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConnectionPostService _connectionPostService;
    private readonly IUserService _userService;
    private readonly IStudentOrganizationService _organizationService;
    private readonly IRelationshipService _relationshipService;

    public IndexModel(ILogger<IndexModel> logger, IConnectionPostService connectionPostService, 
        IUserService userService, IStudentOrganizationService organizationService, 
        IRelationshipService relationshipService)
    {
        _logger = logger;
        _connectionPostService = connectionPostService;
        _userService = userService;
        _organizationService = organizationService;
        _relationshipService = relationshipService;
    }

    public List<ConnectionPost> ActiveConnectionPosts { get; set; } = new List<ConnectionPost>();
    public int TotalUsers { get; set; }
    public int TotalAlumni { get; set; }
    public int TotalStudents { get; set; }
    public int TotalOrganizations { get; set; }
    public int ActiveRelationships { get; set; }
    public bool IsLoggedIn { get; set; }
    public ApplicationUser? CurrentUser { get; set; }

    public async Task OnGetAsync()
    {
        IsLoggedIn = User.Identity?.IsAuthenticated ?? false;
        
        if (IsLoggedIn)
        {
            // Load data for logged-in users
            ActiveConnectionPosts = await _connectionPostService.GetActiveConnectionPostsAsync();
            
            var allUsers = await _userService.GetAllUsersAsync();
            TotalUsers = allUsers.Count;
            TotalAlumni = allUsers.Count(u => u.Type == UserType.Alumni);
            TotalStudents = allUsers.Count(u => u.Type == UserType.Student);
            
            var allOrganizations = await _organizationService.GetAllOrganizationsAsync();
            TotalOrganizations = allOrganizations.Count;
            
            var allRelationships = await _relationshipService.GetAllRelationshipsAsync();
            ActiveRelationships = allRelationships.Count(r => r.Status == "Active");
            
            // Get current user if logged in
            if (User.Identity?.Name != null)
            {
                CurrentUser = await _userService.GetUserByEmailAsync(User.Identity.Name);
            }
        }
    }
}
