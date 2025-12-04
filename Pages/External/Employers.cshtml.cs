using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.External;

public class EmployersModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IJobOfferService _jobOfferService;
    private readonly IConnectionService _connectionService;
    private readonly UserManager<ApplicationUser> _userManager;

    public EmployersModel(
        IUserService userService, 
        IJobOfferService jobOfferService,
        IConnectionService connectionService,
        UserManager<ApplicationUser> userManager)
    {
        _userService = userService;
        _jobOfferService = jobOfferService;
        _connectionService = connectionService;
        _userManager = userManager;
    }

    public List<ApplicationUser> Employers { get; set; } = new List<ApplicationUser>();
    public List<string> Companies { get; set; } = new List<string>();
    public List<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    public ApplicationUser? CurrentUser { get; set; }
    public bool IsExternalUser { get; set; }
    public Dictionary<string, ConnectionStatus?> ConnectionStatuses { get; set; } = new();

    public async Task OnGetAsync()
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        IsExternalUser = CurrentUser?.Type == UserType.External;
        
        Employers = await _userService.GetUsersByTypeAsync(UserType.External);
        Companies = Employers.Where(e => !string.IsNullOrEmpty(e.Company)).Select(e => e.Company).Distinct().ToList();
        
        // Get active job offers
        JobOffers = await _jobOfferService.GetActiveJobOffersAsync();

        // Get connection statuses for all employers if user is logged in
        if (CurrentUser != null)
        {
            foreach (var employer in Employers)
            {
                if (employer.Id != CurrentUser.Id)
                {
                    var connection = await _connectionService.GetConnectionAsync(CurrentUser.Id, employer.Id);
                    ConnectionStatuses[employer.Id] = connection?.Status;
                }
            }
        }
    }

    public async Task<IActionResult> OnPostConnectAsync(string userId)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        if (currentUser.Id == userId)
        {
            return RedirectToPage();
        }

        await _connectionService.CreateConnectionAsync(currentUser.Id, userId);
        return RedirectToPage();
    }
}
