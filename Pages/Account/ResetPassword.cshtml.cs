using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Models;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            public string Code { get; set; } = string.Empty;
        }

        public string StatusMessage { get; set; } = string.Empty;

        public IActionResult OnGet(string? userId = null, string? code = null)
        {
            if (userId == null || code == null)
            {
                StatusMessage = "Invalid password reset token.";
                return Page();
            }

            Input.Code = code;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                TempData["SuccessMessage"] = "Your password has been reset.";
                return RedirectToPage("/Account/Login");
            }

            var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Your password has been reset.";
                return RedirectToPage("/Account/Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}

