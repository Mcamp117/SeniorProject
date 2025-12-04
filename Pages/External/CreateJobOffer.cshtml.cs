using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Models;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.External;

[Authorize]
public class CreateJobOfferModel : PageModel
{
    private readonly IJobOfferService _jobOfferService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateJobOfferModel(IJobOfferService jobOfferService, UserManager<ApplicationUser> userManager)
    {
        _jobOfferService = jobOfferService;
        _userManager = userManager;
    }

    [BindProperty]
    public JobOfferInput Input { get; set; } = new JobOfferInput();

    public string? ErrorMessage { get; set; }
    public ApplicationUser? CurrentUser { get; set; }

    public class JobOfferInput
    {
        [Required(ErrorMessage = "Job title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Job Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Job description is required")]
        [StringLength(3000, ErrorMessage = "Description cannot exceed 3000 characters")]
        [Display(Name = "Job Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Responsibilities are required")]
        [StringLength(3000, ErrorMessage = "Responsibilities cannot exceed 3000 characters")]
        [Display(Name = "Responsibilities")]
        public string Responsibilities { get; set; } = string.Empty;

        [Required(ErrorMessage = "Application link is required")]
        [StringLength(500, ErrorMessage = "Link cannot exceed 500 characters")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "Application Link")]
        public string Link { get; set; } = string.Empty;

        [Required(ErrorMessage = "Application deadline is required")]
        [Display(Name = "Application Deadline")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDeadline { get; set; } = DateTime.UtcNow.AddDays(30);

        [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
        [Display(Name = "Company Name (Optional - defaults to your profile company)")]
        public string? CompanyName { get; set; }

        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        [Display(Name = "Location (Optional)")]
        public string? Location { get; set; }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login");
        }

        // Only External users (employers) can create job offers
        if (user.Type != UserType.External)
        {
            ErrorMessage = "Only external employers can create job offers.";
            return Page();
        }

        CurrentUser = user;
        Input.CompanyName = user.Company;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login");
        }

        if (user.Type != UserType.External)
        {
            ErrorMessage = "Only external employers can create job offers.";
            return Page();
        }

        CurrentUser = user;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Input.ApplicationDeadline <= DateTime.UtcNow)
        {
            ModelState.AddModelError("Input.ApplicationDeadline", "Application deadline must be in the future.");
            return Page();
        }

        var jobOffer = new JobOffer
        {
            Title = Input.Title,
            Description = Input.Description,
            Responsibilities = Input.Responsibilities,
            Link = Input.Link,
            ApplicationDeadline = Input.ApplicationDeadline,
            PosterId = user.Id,
            CompanyName = string.IsNullOrWhiteSpace(Input.CompanyName) ? user.Company : Input.CompanyName,
            Location = Input.Location,
            Status = JobOfferStatus.Active
        };

        await _jobOfferService.CreateJobOfferAsync(jobOffer);
        
        return RedirectToPage("/External/Employers");
    }
}

