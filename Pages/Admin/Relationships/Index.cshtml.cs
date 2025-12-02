using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Relationships;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IRelationshipService _relationshipService;
    private readonly IUserService _userService;

    public IndexModel(IRelationshipService relationshipService, IUserService userService)
    {
        _relationshipService = relationshipService;
        _userService = userService;
    }

    public IList<Relationship> Items { get; set; } = new List<Relationship>();

    public async Task OnGetAsync()
    {
        Items = await _relationshipService.GetAllRelationshipsAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _relationshipService.DeleteRelationshipAsync(id);
        return RedirectToPage();
    }
}

