using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Models;
using EagleConnect.Services;

namespace EagleConnect.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly AuthService _authService;

        public ProfileModel(AuthService authService)
        {
            _authService = authService;
        }

        public ApplicationUser? CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            return Page();
        }
    }
}
