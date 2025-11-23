using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EagleConnect.Models;
using EagleConnect.Data;

namespace EagleConnect.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class ApprovalModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public ApprovalModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public List<ApplicationUser> PendingUsers { get; set; } = new();

    public async Task OnGetAsync()
    {
        PendingUsers = await _context.Users
            .Where(u => !u.IsApproved)
            .OrderBy(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostApproveAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        user.IsApproved = true;
        await _userManager.UpdateAsync(user);

        TempData["SuccessMessage"] = $"User {user.FirstName} {user.LastName} has been approved.";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDenyAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        // Delete the user account
        await _userManager.DeleteAsync(user);

        TempData["SuccessMessage"] = $"User {user.FirstName} {user.LastName} has been denied and removed.";
        return RedirectToPage();
    }
}

