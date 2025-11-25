using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ISkillService _skillService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IWebHostEnvironment _environment;

    public EditModel(IUserService userService, ISkillService skillService, 
        UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IWebHostEnvironment environment)
    {
        _userService = userService;
        _skillService = skillService;
        _userManager = userManager;
        _roleManager = roleManager;
        _environment = environment;
    }

    [BindProperty]
    public UserInputModel Input { get; set; } = new();
    
    public List<string> UserRoles { get; set; } = new();
    public List<Skill> AvailableSkills { get; set; } = new();
    public List<UserSkill> UserSkills { get; set; } = new();
    public string? CurrentProfileImage { get; set; }

    public class UserInputModel
    {
        public string Id { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        
        [Display(Name = "User Type")]
        public UserType Type { get; set; }
        
        [Display(Name = "Company")]
        public string? Company { get; set; }
        
        [Display(Name = "Job Title")]
        public string? JobTitle { get; set; }
        
        [Display(Name = "Graduation Year")]
        public int? GraduationYear { get; set; }
        
        [Display(Name = "Bio")]
        public string? Bio { get; set; }
        
        [Display(Name = "Account Active")]
        public bool IsApproved { get; set; }
        
        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }
    }

    [BindProperty]
    public IFormFile? ProfileImageFile { get; set; }

    [BindProperty]
    public PasswordInputModel PasswordInput { get; set; } = new();

    public class PasswordInputModel
    {
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // Map user to input model
        Input = new UserInputModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber,
            Type = user.Type,
            Company = user.Company,
            JobTitle = user.JobTitle,
            GraduationYear = user.GraduationYear,
            Bio = user.Bio,
            IsApproved = user.IsApproved,
            EmailConfirmed = user.EmailConfirmed
        };

        CurrentProfileImage = user.ProfileImage;
        UserSkills = user.UserSkills?.ToList() ?? new List<UserSkill>();

        // Load user roles
        UserRoles = (await _userManager.GetRolesAsync(user)).ToList();
        
        // Load available skills
        AvailableSkills = await _skillService.GetAllSkillsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Validate that we have a user ID
        if (string.IsNullOrEmpty(Input.Id))
        {
            ModelState.AddModelError("", "User ID is required.");
            await LoadPageData(Input.Id);
            return Page();
        }

        // Remove password validation from main form if not provided
        if (string.IsNullOrEmpty(PasswordInput.NewPassword))
        {
            ModelState.Remove("PasswordInput.NewPassword");
            ModelState.Remove("PasswordInput.ConfirmPassword");
        }

        if (!ModelState.IsValid)
        {
            await LoadPageData(Input.Id);
            return Page();
        }

        try
        {
            var user = await _userManager.FindByIdAsync(Input.Id);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                await LoadPageData(Input.Id);
                return Page();
            }

            // Handle profile image upload
            string? profileImagePath = null;
            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                profileImagePath = await SaveProfileImageAsync(ProfileImageFile, Input.Id);
            }

            // Update user properties
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.PhoneNumber = Input.PhoneNumber;
            user.Type = Input.Type;
            user.Company = Input.Company ?? string.Empty;
            user.JobTitle = Input.JobTitle ?? string.Empty;
            user.GraduationYear = Input.GraduationYear;
            user.Bio = Input.Bio ?? string.Empty;
            user.IsApproved = Input.IsApproved;
            user.EmailConfirmed = Input.EmailConfirmed;

            if (profileImagePath != null)
            {
                user.ProfileImage = profileImagePath;
            }

            // Handle email change
            if (user.Email != Input.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    foreach (var error in setEmailResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    await LoadPageData(Input.Id);
                    return Page();
                }
                user.UserName = Input.Email; // Keep username in sync
            }

            // Update user
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                await LoadPageData(Input.Id);
                return Page();
            }

            TempData["SuccessMessage"] = "User updated successfully.";
            return RedirectToPage(new { id = Input.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error updating user: {ex.Message}");
            await LoadPageData(Input.Id);
            return Page();
        }
    }

    public async Task<IActionResult> OnPostResetPasswordAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            TempData["ErrorMessage"] = "User ID is required.";
            return RedirectToPage(new { id = userId });
        }

        if (string.IsNullOrEmpty(PasswordInput.NewPassword))
        {
            TempData["ErrorMessage"] = "New password is required.";
            return RedirectToPage(new { id = userId });
        }

        if (PasswordInput.NewPassword != PasswordInput.ConfirmPassword)
        {
            TempData["ErrorMessage"] = "Passwords do not match.";
            return RedirectToPage(new { id = userId });
        }

        if (PasswordInput.NewPassword.Length < 6)
        {
            TempData["ErrorMessage"] = "Password must be at least 6 characters.";
            return RedirectToPage(new { id = userId });
        }

        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToPage(new { id = userId });
            }

            // Remove existing password and set new one
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, PasswordInput.NewPassword);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Password reset successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error resetting password: " + string.Join(", ", result.Errors.Select(e => e.Description));
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error resetting password: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    public async Task<IActionResult> OnPostToggleActivationAsync(string userId, bool activate)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToPage(new { id = userId });
            }

            user.IsApproved = activate;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = activate ? "User activated successfully." : "User deactivated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error updating user status.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    public async Task<IActionResult> OnPostAddSkillAsync(string userId, int skillId, string proficiencyLevel, string notes)
    {
        try
        {
            await _userService.AddSkillToUserAsync(userId, skillId, proficiencyLevel, notes);
            TempData["SuccessMessage"] = "Skill added successfully.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error adding skill: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    public async Task<IActionResult> OnPostRemoveSkillAsync(string userId, int skillId)
    {
        try
        {
            await _userService.RemoveSkillFromUserAsync(userId, skillId);
            TempData["SuccessMessage"] = "Skill removed successfully.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error removing skill: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    public async Task<IActionResult> OnPostAddRoleAsync(string userId, string role)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role);
                TempData["SuccessMessage"] = "Role added successfully.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error adding role: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    public async Task<IActionResult> OnPostRemoveRoleAsync(string userId, string role)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
                TempData["SuccessMessage"] = "Role removed successfully.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error removing role: {ex.Message}";
        }

        return RedirectToPage(new { id = userId });
    }

    private async Task LoadPageData(string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user != null)
            {
                CurrentProfileImage = user.ProfileImage;
                UserSkills = user.UserSkills?.ToList() ?? new List<UserSkill>();
                UserRoles = (await _userManager.GetRolesAsync(user)).ToList();
            }
        }
        AvailableSkills = await _skillService.GetAllSkillsAsync();
    }

    private async Task<string> SaveProfileImageAsync(IFormFile file, string userId)
    {
        // Validate file type
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        
        if (!allowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException("Invalid file type. Allowed types: jpg, jpeg, png, gif, webp");
        }

        // Validate file size (max 5MB)
        if (file.Length > 5 * 1024 * 1024)
        {
            throw new InvalidOperationException("File size exceeds 5MB limit.");
        }

        // Create profiles directory if it doesn't exist
        var profilesPath = Path.Combine(_environment.WebRootPath, "images", "profiles");
        if (!Directory.Exists(profilesPath))
        {
            Directory.CreateDirectory(profilesPath);
        }

        // Generate unique filename
        var fileName = $"{userId}_{DateTime.UtcNow.Ticks}{extension}";
        var filePath = Path.Combine(profilesPath, fileName);

        // Save file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/images/profiles/{fileName}";
    }
}
