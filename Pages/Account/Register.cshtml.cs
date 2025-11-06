using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Models;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AuthService _authService;

        public RegisterModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
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

            [Required]
            [Display(Name = "User Type")]
            public UserType UserType { get; set; }

            [Display(Name = "Graduation Year")]
            public int? GraduationYear { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate graduation year for Alumni
            if (Input.UserType == UserType.Alumni && (!Input.GraduationYear.HasValue || Input.GraduationYear.Value <= 0))
            {
                ModelState.AddModelError("Input.GraduationYear", "Graduation Year is required for Alumni.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.RegisterAsync(
                Input.Email,
                Input.Password,
                Input.FirstName,
                Input.LastName,
                Input.UserType,
                Input.GraduationYear
            );

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
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
