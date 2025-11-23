using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using EagleConnect.Models;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ForgotPasswordModel(
            UserManager<ApplicationUser> userManager,
            IEmailService emailService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; } = string.Empty;
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

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                TempData["SuccessMessage"] = "If an account with that email exists, a password reset link has been sent.";
                return RedirectToPage("/Account/Login");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            // Use configured base URL or fallback to current request
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                baseUrl = $"{Request.Scheme}://{Request.Host}";
            }
            
            var callbackUrl = $"{baseUrl.TrimEnd('/')}/Account/ResetPassword?userId={Uri.EscapeDataString(user.Id)}&code={Uri.EscapeDataString(token)}";

            await _emailService.SendPasswordResetAsync(Input.Email, callbackUrl);

            TempData["SuccessMessage"] = "If an account with that email exists, a password reset link has been sent.";
            return RedirectToPage("/Account/Login");
        }
    }
}

