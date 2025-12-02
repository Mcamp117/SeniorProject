using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Organizations;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
    {
        private readonly IStudentOrganizationService _organizationService;

        public IndexModel(IStudentOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public IList<StudentOrganization> Organizations { get; set; } = new List<StudentOrganization>();

        public async Task OnGetAsync()
        {
            Organizations = await _organizationService.GetAllOrganizationsAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _organizationService.DeleteOrganizationAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleActiveAsync(int id)
        {
            var org = await _organizationService.GetOrganizationByIdAsync(id);
            if (org != null)
            {
                org.IsActive = !org.IsActive;
                await _organizationService.UpdateOrganizationAsync(org);
            }
            return RedirectToPage();
        }
    }
