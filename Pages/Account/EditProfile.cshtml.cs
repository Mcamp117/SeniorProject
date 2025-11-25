using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Models;
using EagleConnect.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace EagleConnect.Pages.Account
{
    [Authorize]
    public class EditProfileModel : PageModel
    {
        private readonly AuthService _authService;
        private readonly IUserService _userService;

        public EditProfileModel(AuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public ApplicationUser? CurrentUser { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            [StringLength(50)]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Last Name")]
            [StringLength(50)]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; } = string.Empty;

            [Display(Name = "Company")]
            [StringLength(100)]
            public string? Company { get; set; }

            [Display(Name = "Job Title")]
            [StringLength(100)]
            public string? JobTitle { get; set; }

            [Display(Name = "Graduation Year")]
            public int? GraduationYear { get; set; }

            [Display(Name = "Profile Image URL")]
            [StringLength(255)]
            public string? ProfileImage { get; set; }

            [Display(Name = "Profile Image File")]
            [DataType(DataType.Upload)]
            public IFormFile? ProfileImageFile { get; set; }

            [Display(Name = "Bio")]
            [StringLength(500)]
            public string? Bio { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            // Populate the form with current user data
            Input.FirstName = CurrentUser.FirstName;
            Input.LastName = CurrentUser.LastName;
            Input.Email = CurrentUser.Email ?? string.Empty;
            Input.Company = string.IsNullOrWhiteSpace(CurrentUser.Company) ? null : CurrentUser.Company;
            Input.JobTitle = string.IsNullOrWhiteSpace(CurrentUser.JobTitle) ? null : CurrentUser.JobTitle;
            Input.GraduationYear = CurrentUser.GraduationYear == 0 ? null : CurrentUser.GraduationYear;
            Input.ProfileImage = string.IsNullOrWhiteSpace(CurrentUser.ProfileImage) ? "/images/default-avatar.svg" : CurrentUser.ProfileImage;
            Input.Bio = string.IsNullOrWhiteSpace(CurrentUser.Bio) ? null : CurrentUser.Bio;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Remove validation errors for optional fields - they can be empty
            ModelState.Remove("Input.Bio");
            ModelState.Remove("Input.Company");
            ModelState.Remove("Input.JobTitle");
            ModelState.Remove("Input.ProfileImage");
            ModelState.Remove("Input.ProfileImageFile");
            ModelState.Remove("Input.GraduationYear");
            
            // Validate GraduationYear if provided (must be >= 1900)
            if (Input.GraduationYear.HasValue && Input.GraduationYear.Value > 0)
            {
                if (Input.GraduationYear.Value < 1900)
                {
                    ModelState.AddModelError("Input.GraduationYear", "Graduation year must be 1900 or later.");
                }
                else if (Input.GraduationYear.Value > DateTime.Now.Year + 10)
                {
                    ModelState.AddModelError("Input.GraduationYear", $"Graduation year cannot be more than {DateTime.Now.Year + 10}.");
                }
            }
            
            // Only validate required fields
            if (string.IsNullOrWhiteSpace(Input.FirstName))
            {
                ModelState.AddModelError("Input.FirstName", "First Name is required.");
            }
            if (string.IsNullOrWhiteSpace(Input.LastName))
            {
                ModelState.AddModelError("Input.LastName", "Last Name is required.");
            }
            if (string.IsNullOrWhiteSpace(Input.Email))
            {
                ModelState.AddModelError("Input.Email", "Email is required.");
            }
            else if (!Regex.IsMatch(Input.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ModelState.AddModelError("Input.Email", "Email format is invalid.");
            }

            if (!ModelState.IsValid)
            {
                CurrentUser = await _authService.GetCurrentUserAsync(User);
                return Page();
            }

            CurrentUser = await _authService.GetCurrentUserAsync(User);
            
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                // Handle profile image upload
                string profileImagePath = CurrentUser.ProfileImage ?? "/images/default-avatar.svg";
                
                if (Input.ProfileImageFile != null && Input.ProfileImageFile.Length > 0)
                {
                    // Validate file type
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                    var fileExtension = Path.GetExtension(Input.ProfileImageFile.FileName).ToLowerInvariant();
                    
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Input.ProfileImageFile", "Only PNG, JPG, and JPEG files are allowed.");
                        CurrentUser = await _authService.GetCurrentUserAsync(User);
                        return Page();
                    }

                    // Validate file size (5MB max)
                    const long maxFileSize = 5 * 1024 * 1024; // 5MB
                    if (Input.ProfileImageFile.Length > maxFileSize)
                    {
                        ModelState.AddModelError("Input.ProfileImageFile", "File size must be less than 5MB.");
                        CurrentUser = await _authService.GetCurrentUserAsync(User);
                        return Page();
                    }

                    // Create profiles directory if it doesn't exist
                    var profilesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profiles");
                    if (!Directory.Exists(profilesDirectory))
                    {
                        Directory.CreateDirectory(profilesDirectory);
                    }

                    // Generate unique filename using user ID
                    var fileName = $"{CurrentUser.Id}{fileExtension}";
                    var filePath = Path.Combine(profilesDirectory, fileName);
                    
                    // Delete old profile image if it exists and is not the default
                    if (!string.IsNullOrEmpty(CurrentUser.ProfileImage) && 
                        CurrentUser.ProfileImage != "/images/default-avatar.svg" &&
                        CurrentUser.ProfileImage.StartsWith("/images/profiles/"))
                    {
                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CurrentUser.ProfileImage.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            try
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                            catch
                            {
                                // Ignore errors when deleting old file
                            }
                        }
                    }

                    // Save the new file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Input.ProfileImageFile.CopyToAsync(stream);
                    }

                    // Set the profile image path
                    profileImagePath = $"/images/profiles/{fileName}";
                }

                // Update the user properties
                CurrentUser.FirstName = Input.FirstName;
                CurrentUser.LastName = Input.LastName;
                CurrentUser.Email = Input.Email;
                CurrentUser.UserName = Input.Email; // Keep username in sync with email
                // Note: User Type can only be changed by admins, so we don't update it here
                CurrentUser.Company = Input.Company ?? string.Empty;
                CurrentUser.JobTitle = Input.JobTitle ?? string.Empty;
                // Only set GraduationYear if a valid value is provided (not null and > 0)
                CurrentUser.GraduationYear = (Input.GraduationYear.HasValue && Input.GraduationYear.Value > 0) ? Input.GraduationYear.Value : 0;
                CurrentUser.ProfileImage = profileImagePath;
                CurrentUser.Bio = Input.Bio ?? string.Empty;

                // Use UserService to update
                await _userService.UpdateUserAsync(CurrentUser);

                TempData["SuccessMessage"] = "Profile updated successfully.";
                return RedirectToPage("/Account/Profile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating profile: {ex.Message}");
                CurrentUser = await _authService.GetCurrentUserAsync(User);
                return Page();
            }
        }
    }
}

