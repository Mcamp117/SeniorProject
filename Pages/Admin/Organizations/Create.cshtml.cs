using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Organizations;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
    {
        private readonly IStudentOrganizationService _organizationService;

        public CreateModel(IStudentOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [BindProperty]
        public StudentOrganization Organization { get; set; } = new StudentOrganization();

        public IActionResult OnGet()
        {
            Organization.CreatedDate = DateTime.UtcNow;
            Organization.IsActive = true;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _organizationService.CreateOrganizationAsync(Organization);
            return RedirectToPage("./Index");
        }
    }
