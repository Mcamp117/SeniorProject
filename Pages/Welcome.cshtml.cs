using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;

namespace EagleConnect.Pages
{
    public class WelcomeModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRelationshipService _relationshipService;
        private readonly IStudentOrganizationService _organizationService;
        private readonly IConnectionPostService _connectionPostService;

        public WelcomeModel(IUserService userService, IRelationshipService relationshipService, 
            IStudentOrganizationService organizationService, IConnectionPostService connectionPostService)
        {
            _userService = userService;
            _relationshipService = relationshipService;
            _organizationService = organizationService;
            _connectionPostService = connectionPostService;
        }

        public int TotalUsers { get; set; }
        public int ActiveConnections { get; set; }
        public int TotalOrganizations { get; set; }
        public int JobOpportunities { get; set; }

        public async Task OnGetAsync()
        {
            // Get stats from database services
            var allUsers = await _userService.GetAllUsersAsync();
            TotalUsers = allUsers.Count;
            
            var allRelationships = await _relationshipService.GetAllRelationshipsAsync();
            ActiveConnections = allRelationships.Count(r => r.Status == "Active");
            
            var allOrganizations = await _organizationService.GetAllOrganizationsAsync();
            TotalOrganizations = allOrganizations.Count;
            
            var allPosts = await _connectionPostService.GetAllConnectionPostsAsync();
            JobOpportunities = allPosts.Count(p => p.Type == Models.ConnectionType.Internship);
        }
    }
}
