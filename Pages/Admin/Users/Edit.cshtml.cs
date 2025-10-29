using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

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
    public ApplicationUser UserModel { get; set; } = new();
    
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
        if (!ModelState.IsValid)
        {
            // Reload data for the page
            UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();
            AvailableSkills = await _skillService.GetAllSkillsAsync();
            return Page();
        }

        try
        {
            await _userService.UpdateUserAsync(UserModel);
            TempData["SuccessMessage"] = "User updated successfully.";
            return RedirectToPage("/Admin/Users/Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error updating user: {ex.Message}");
            UserRoles = (await _userManager.GetRolesAsync(UserModel)).ToList();
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
