using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.LoginAsync(Input.Email, Input.Password, Input.RememberMe);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is locked out. Please try again later.");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "Your account is pending approval by an administrator. Please wait for approval before logging in.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }
    }
}
