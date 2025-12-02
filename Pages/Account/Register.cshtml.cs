using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using EagleConnect.Models;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EagleConnect.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public RegisterModel(
            AuthService authService,
            UserManager<ApplicationUser> userManager,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _authService = authService;
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
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
            [Display(Name = "I am a")]
            public UserType UserType { get; set; }

            // Alumni fields
            [Display(Name = "Graduation Year")]
            public int? GraduationYear { get; set; }

            // Professional fields (Alumni, External, Faculty)
            [Display(Name = "Company")]
            public string? Company { get; set; }

            [Display(Name = "Job Title")]
            public string? JobTitle { get; set; }
        }

        public int CurrentStep { get; set; } = 1;

        public void OnGet(int step = 1)
        {
            CurrentStep = step;
            
            // Restore step 1 data from TempData if available
            if (TempData.ContainsKey("Step1_FirstName"))
            {
                Input.FirstName = TempData["Step1_FirstName"]?.ToString() ?? string.Empty;
                Input.LastName = TempData["Step1_LastName"]?.ToString() ?? string.Empty;
                Input.Email = TempData["Step1_Email"]?.ToString() ?? string.Empty;
                if (TempData.ContainsKey("Step1_UserType") && Enum.TryParse<UserType>(TempData["Step1_UserType"]?.ToString(), out var userType))
                    Input.UserType = userType;
            }
            // Preserve form values from query string if going back (except passwords for security)
            else if (Request.Query.ContainsKey("Input.FirstName"))
            {
                Input.FirstName = Request.Query["Input.FirstName"].ToString();
                Input.LastName = Request.Query["Input.LastName"].ToString();
                Input.Email = Request.Query["Input.Email"].ToString();
                if (Request.Query.ContainsKey("Input.UserType") && Enum.TryParse<UserType>(Request.Query["Input.UserType"].ToString(), out var userType))
                    Input.UserType = userType;
            }
            // If on step 2 but no user type set, default to Student
            if (CurrentStep == 2 && Input.UserType == 0)
            {
                Input.UserType = UserType.Student;
            }
        }

        public async Task<IActionResult> OnPostAsync(string? action = null)
        {
            // Handle step navigation
            if (action == "next")
            {
                // Clear ModelState to validate only step 1 fields
                ModelState.Clear();
                
                // Validate step 1 fields
                if (string.IsNullOrWhiteSpace(Input.FirstName))
                    ModelState.AddModelError("Input.FirstName", "First Name is required.");
                if (string.IsNullOrWhiteSpace(Input.LastName))
                    ModelState.AddModelError("Input.LastName", "Last Name is required.");
                if (string.IsNullOrWhiteSpace(Input.Email))
                    ModelState.AddModelError("Input.Email", "Email is required.");
                else if (!System.Text.RegularExpressions.Regex.IsMatch(Input.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    ModelState.AddModelError("Input.Email", "Email format is invalid.");
                
                // Validate password with all Identity requirements
                if (string.IsNullOrWhiteSpace(Input.Password))
                {
                    ModelState.AddModelError("Input.Password", "Password is required.");
                }
                else
                {
                    if (Input.Password.Length < 6)
                        ModelState.AddModelError("Input.Password", "Password must be at least 6 characters long.");
                    if (!Input.Password.Any(char.IsDigit))
                        ModelState.AddModelError("Input.Password", "Passwords must have at least one digit ('0'-'9').");
                    if (!Input.Password.Any(char.IsLower))
                        ModelState.AddModelError("Input.Password", "Passwords must have at least one lowercase ('a'-'z').");
                    if (!Input.Password.Any(char.IsUpper))
                        ModelState.AddModelError("Input.Password", "Passwords must have at least one uppercase ('A'-'Z').");
                }
                
                if (string.IsNullOrWhiteSpace(Input.ConfirmPassword))
                    ModelState.AddModelError("Input.ConfirmPassword", "Please confirm your password.");
                else if (Input.Password != Input.ConfirmPassword)
                    ModelState.AddModelError("Input.ConfirmPassword", "Passwords do not match.");

                if (ModelState.IsValid)
                {
                    // Store step 1 data in TempData for step 2
                    TempData["Step1_FirstName"] = Input.FirstName;
                    TempData["Step1_LastName"] = Input.LastName;
                    TempData["Step1_Email"] = Input.Email;
                    TempData["Step1_Password"] = Input.Password;
                    TempData["Step1_UserType"] = Input.UserType.ToString();
                    
                    CurrentStep = 2;
                    return Page();
                }
                CurrentStep = 1;
                return Page();
            }

            // Final submission - restore step 1 data from TempData
            if (TempData.ContainsKey("Step1_Password"))
            {
                Input.FirstName = TempData["Step1_FirstName"]?.ToString() ?? Input.FirstName;
                Input.LastName = TempData["Step1_LastName"]?.ToString() ?? Input.LastName;
                Input.Email = TempData["Step1_Email"]?.ToString() ?? Input.Email;
                Input.Password = TempData["Step1_Password"]?.ToString() ?? Input.Password;
                Input.ConfirmPassword = Input.Password; // Set confirm password to match
                if (TempData.ContainsKey("Step1_UserType") && Enum.TryParse<UserType>(TempData["Step1_UserType"]?.ToString(), out var userType))
                    Input.UserType = userType;
            }

            // Clear ModelState - step 1 fields are already validated, only validate step 2 specific fields
            ModelState.Clear();
            
            // Only validate step 2 specific fields (step 1 fields were already validated)
            // Validate type-specific fields
            if (Input.UserType == UserType.Alumni)
            {
                if (!Input.GraduationYear.HasValue || Input.GraduationYear.Value <= 0)
                {
                    ModelState.AddModelError("Input.GraduationYear", "Graduation Year is required for Alumni.");
                }
            }

            // Hard code Faculty company to USI
            string company = Input.Company ?? string.Empty;
            if (Input.UserType == UserType.Faculty)
            {
                company = "USI";
            }

            if (!ModelState.IsValid)
            {
                CurrentStep = 2;
                return Page();
            }

            var result = await _authService.RegisterAsync(
                Input.Email,
                Input.Password,
                Input.FirstName,
                Input.LastName,
                Input.UserType,
                Input.GraduationYear,
                company,
                Input.JobTitle
            );

            if (result.Succeeded)
            {
                // Get the newly created user
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user != null)
                {
                    // Generate email confirmation token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    
                    // Use configured base URL or fallback to current request
                    var baseUrl = _configuration["AppSettings:BaseUrl"];
                    if (string.IsNullOrEmpty(baseUrl))
                    {
                        baseUrl = $"{Request.Scheme}://{Request.Host}";
                    }
                    
                    var callbackUrl = $"{baseUrl.TrimEnd('/')}/Account/ConfirmEmail?userId={Uri.EscapeDataString(user.Id)}&code={Uri.EscapeDataString(token)}";

                    // Send email confirmation
                    await _emailService.SendEmailConfirmationAsync(Input.Email, callbackUrl);
                }

                // Clear TempData
                TempData.Remove("Step1_FirstName");
                TempData.Remove("Step1_LastName");
                TempData.Remove("Step1_Email");
                TempData.Remove("Step1_Password");
                TempData.Remove("Step1_UserType");
                
                TempData["SuccessMessage"] = "Registration successful! Please check your email to confirm your account. Your account is also pending approval by an administrator. You will be able to log in once your account is approved and email is confirmed.";
                return RedirectToPage("/Account/Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            CurrentStep = 2;
            return Page();
        }
    }
}
