using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Relationships;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IRelationshipService _relationshipService;
    private readonly IUserService _userService;

    public EditModel(IRelationshipService relationshipService, IUserService userService)
    {
        _relationshipService = relationshipService;
        _userService = userService;
    }

    [BindProperty]
    public Relationship Item { get; set; } = new Relationship();

    public IList<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var r = await _relationshipService.GetRelationshipByIdAsync(id);
        if (r == null) return NotFound();
        Item = r;
        Users = await _userService.GetAllUsersAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Users = await _userService.GetAllUsersAsync();
            return Page();
        }

        await _relationshipService.UpdateRelationshipAsync(Item);
        return RedirectToPage("./Index");
    }
}

