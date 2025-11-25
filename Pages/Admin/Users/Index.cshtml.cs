using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IUserService _userService;

    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }

    public List<ApplicationUser> Users { get; set; } = new();
    public Dictionary<string, List<string>> UserRoles { get; set; } = new();
    
    [FromQuery(Name = "searchTerm")]
    public string SearchTerm { get; set; } = string.Empty;
    
    [FromQuery(Name = "userType")]
    public string SelectedUserType { get; set; } = string.Empty;
    
    [FromQuery(Name = "role")]
    public string SelectedRole { get; set; } = string.Empty;
    
    [FromQuery(Name = "p")]
    public int CurrentPage { get; set; } = 1;
    
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = 10;

    public async Task OnGetAsync()
    {
        var allUsers = await _userService.GetAllUsersAsync();
        
        // Apply filters
        var filteredUsers = allUsers.AsQueryable();
        
        if (!string.IsNullOrEmpty(SearchTerm))
        {
            filteredUsers = filteredUsers.Where(u => 
                u.FirstName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.LastName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                (!string.IsNullOrEmpty(u.Email) && u.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)));
        }
        
        if (!string.IsNullOrEmpty(SelectedUserType) && Enum.TryParse<UserType>(SelectedUserType, out var userType))
        {
            filteredUsers = filteredUsers.Where(u => u.Type == userType);
        }
        
        // Get user roles
        UserRoles = await _userService.GetUserRolesAsync();
        
        if (!string.IsNullOrEmpty(SelectedRole))
        {
            var usersWithRole = UserRoles.Where(kvp => kvp.Value.Contains(SelectedRole)).Select(kvp => kvp.Key).ToList();
            filteredUsers = filteredUsers.Where(u => usersWithRole.Contains(u.Id));
        }
        
        // Apply pagination
        var totalCount = filteredUsers.Count();
        TotalPages = (int)Math.Ceiling((double)totalCount / PageSize);
        
        // Ensure page is within valid range
        var safePage = Math.Max(1, Math.Min(CurrentPage, Math.Max(1, TotalPages)));
        
        Users = filteredUsers
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .Skip((safePage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        try
        {
            await _userService.DeleteUserAsync(id);
            TempData["SuccessMessage"] = "User deleted successfully.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error deleting user: {ex.Message}";
        }

        return RedirectToPage(new { p = CurrentPage, searchTerm = SearchTerm, userType = SelectedUserType, role = SelectedRole });
    }
}
