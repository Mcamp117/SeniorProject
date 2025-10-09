using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages;

public class PeopleModel : PageModel
{
    private readonly StaticDataService _dataService;

    public PeopleModel(StaticDataService dataService)
    {
        _dataService = dataService;
    }

    public List<User> AllUsers { get; set; } = new List<User>();
    public List<User> FilteredUsers { get; set; } = new List<User>();
    public string SearchTerm { get; set; } = string.Empty;
    public string SelectedType { get; set; } = string.Empty;
    public string SelectedMajor { get; set; } = string.Empty;
    public List<string> AvailableMajors { get; set; } = new List<string>();

    public void OnGet(string search, string type, string major)
    {
        AllUsers = _dataService.Users;
        SearchTerm = search ?? string.Empty;
        SelectedType = type ?? string.Empty;
        SelectedMajor = major ?? string.Empty;

        // Get available majors for filter dropdown
        AvailableMajors = AllUsers.Select(u => u.Major).Where(m => !string.IsNullOrEmpty(m)).Distinct().OrderBy(m => m).ToList();

        // Apply filters
        var query = AllUsers.AsQueryable();

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            query = query.Where(u => 
                u.FirstName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.LastName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.Company.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.JobTitle.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.Skills.Any(s => s.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            );
        }

        if (!string.IsNullOrEmpty(SelectedType))
        {
            if (Enum.TryParse<UserType>(SelectedType, out var userType))
            {
                query = query.Where(u => u.Type == userType);
            }
        }

        if (!string.IsNullOrEmpty(SelectedMajor))
        {
            query = query.Where(u => u.Major.Contains(SelectedMajor, StringComparison.OrdinalIgnoreCase));
        }

        FilteredUsers = query.ToList();
    }
}
