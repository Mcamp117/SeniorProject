using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Alumni;

[Authorize]
public class NetworkingModel : PageModel
{
    private readonly IUserService _userService;
    private readonly AuthService _authService;
    private readonly IConnectionService _connectionService;
    private readonly IRelationshipService _relationshipService;

    public NetworkingModel(
        IUserService userService, 
        AuthService authService, 
        IConnectionService connectionService,
        IRelationshipService relationshipService)
    {
        _userService = userService;
        _authService = authService;
        _connectionService = connectionService;
        _relationshipService = relationshipService;
    }

    public List<ApplicationUser> Alumni { get; set; } = new List<ApplicationUser>();
    public List<string> Industries { get; set; } = new List<string>();
    public List<string> Companies { get; set; } = new List<string>();
    public List<Relationship> ActiveMentorships { get; set; } = new List<Relationship>();
    public ApplicationUser? CurrentUser { get; set; }
    public Dictionary<string, bool> ConnectionStatuses { get; set; } = new();

    public async Task OnGetAsync()
    {
        Alumni = await _userService.GetUsersByTypeAsync(UserType.Alumni);
        Industries = Alumni.Select(a => GetIndustryFromCompany(a.Company)).Distinct().ToList();
        Companies = Alumni.Select(a => a.Company).Distinct().ToList();
        var allMentorships = await _relationshipService.GetRelationshipsByTypeAsync(RelationshipType.AlumniStudent);
        ActiveMentorships = allMentorships.Where(r => r.Status == "Active").ToList();

        // Get current user and check connection statuses
        if (User.Identity?.IsAuthenticated == true)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            
            if (CurrentUser != null)
            {
                foreach (var alum in Alumni)
                {
                    if (alum.Id != CurrentUser.Id)
                    {
                        ConnectionStatuses[alum.Id] = await _connectionService.AreConnectedAsync(CurrentUser.Id, alum.Id);
                    }
                }
            }
        }
    }

    public async Task<int?> GetConnectionIdAsync(string otherUserId)
    {
        if (CurrentUser == null) return null;
        var connection = await _connectionService.GetConnectionAsync(CurrentUser.Id, otherUserId);
        return connection?.Id;
    }

    private string GetIndustryFromCompany(string company)
    {
        return company.ToLower() switch
        {
            var c when c.Contains("microsoft") || c.Contains("tech") => "Technology",
            var c when c.Contains("procter") || c.Contains("gamble") => "Consumer Goods",
            var c when c.Contains("hospital") || c.Contains("medical") => "Healthcare",
            _ => "Other"
        };
    }
}
