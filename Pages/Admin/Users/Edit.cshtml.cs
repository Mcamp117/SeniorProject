using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;
using System.Text.RegularExpressions;

namespace EagleConnect.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ISkillService _skillService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public EditModel(IUserService userService, ISkillService skillService, 
        UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userService = userService;
        _skillService = skillService;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [BindProperty]
    public ApplicationUser? UserModel { get; set; }
    
    public List<string> UserRoles { get; set; } = new();
    public List<Skill> AvailableSkills { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        UserModel = await _userService.GetUserByIdAsync(id);
        if (UserModel == null)
        {
            return NotFound();
        }

        // Load user roles
        UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();
        
        // Load available skills
        AvailableSkills = await _skillService.GetAllSkillsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Validate that we have a user ID
        if (UserModel == null || string.IsNullOrEmpty(UserModel.Id))
        {
            ModelState.AddModelError("", "User ID is required.");
            UserRoles = new List<string>();
            AvailableSkills = await _skillService.GetAllSkillsAsync();
            return Page();
        }

        // Remove validation errors for optional fields - they can be empty
        ModelState.Remove("UserModel.Bio");
        ModelState.Remove("UserModel.Company");
        ModelState.Remove("UserModel.JobTitle");
        ModelState.Remove("UserModel.ProfileImage");
        
        // Only validate required fields
        if (string.IsNullOrWhiteSpace(UserModel.FirstName))
        {
            ModelState.AddModelError("UserModel.FirstName", "First Name is required.");
        }
        if (string.IsNullOrWhiteSpace(UserModel.LastName))
        {
            ModelState.AddModelError("UserModel.LastName", "Last Name is required.");
        }
        if (string.IsNullOrWhiteSpace(UserModel.Email))
        {
            ModelState.AddModelError("UserModel.Email", "Email is required.");
        }
        else if (!Regex.IsMatch(UserModel.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ModelState.AddModelError("UserModel.Email", "Email format is invalid.");
        }

        if (!ModelState.IsValid)
        {
            // Reload the user and data for the page
            var existingUser = await _userService.GetUserByIdAsync(UserModel.Id);
            if (existingUser != null)
            {
                UserModel = existingUser;
                UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();
            }
            else
            {
                UserRoles = new List<string>();
            }
            AvailableSkills = await _skillService.GetAllSkillsAsync();
            return Page();
        }

        try
        {
            if (UserModel != null)
            {
                await _userService.UpdateUserAsync(UserModel);
                TempData["SuccessMessage"] = "User updated successfully.";
                return RedirectToPage("/Admin/Users/Index");
            }
            ModelState.AddModelError("", "User model is null.");
            UserRoles = new List<string>();
            AvailableSkills = await _skillService.GetAllSkillsAsync();
            return Page();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error updating user: {ex.Message}");
            // Reload the user and data for the page
            if (UserModel != null)
            {
                var existingUser = await _userService.GetUserByIdAsync(UserModel.Id);
                if (existingUser != null)
                {
                    UserModel = existingUser;
                    UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();
                }
                else
                {
                    UserRoles = new List<string>();
                }
            }
            else
            {
                UserRoles = new List<string>();
            }
            AvailableSkills = await _skillService.GetAllSkillsAsync();
            return Page();
        }
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
}
