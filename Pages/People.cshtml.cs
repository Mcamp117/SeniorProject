using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

[Authorize]
public class PeopleModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ISkillService _skillService;

    public PeopleModel(IUserService userService, ISkillService skillService)
    {
        _userService = userService;
        _skillService = skillService;
    }

    public List<ApplicationUser> AllUsers { get; set; } = new List<ApplicationUser>();
    public List<ApplicationUser> FilteredUsers { get; set; } = new List<ApplicationUser>();
    public string SearchTerm { get; set; } = string.Empty;
    public string SelectedType { get; set; } = string.Empty;
    public string SelectedSkill { get; set; } = string.Empty;
    public List<Skill> AvailableSkills { get; set; } = new List<Skill>();

    public async Task OnGetAsync(string search, string type, string skill)
    {
        AllUsers = await _userService.GetAllUsersAsync();
        SearchTerm = search ?? string.Empty;
        SelectedType = type ?? string.Empty;
        SelectedSkill = skill ?? string.Empty;

        // Get available skills for filter dropdown
        AvailableSkills = await _skillService.GetAllSkillsAsync();

        // Apply filters
        var query = AllUsers.AsQueryable();

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            query = query.Where(u => 
                u.FirstName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.LastName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.Company.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.JobTitle.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.UserSkills.Any(us => us.Skill!.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            );
        }

        if (!string.IsNullOrEmpty(SelectedType))
        {
            if (Enum.TryParse<UserType>(SelectedType, out var userType))
            {
                query = query.Where(u => u.Type == userType);
            }
        }

        if (!string.IsNullOrEmpty(SelectedSkill))
        {
            if (int.TryParse(SelectedSkill, out var skillId))
            {
                query = query.Where(u => u.UserSkills.Any(us => us.SkillId == skillId));
            }
        }

        FilteredUsers = query.ToList();
    }
}
