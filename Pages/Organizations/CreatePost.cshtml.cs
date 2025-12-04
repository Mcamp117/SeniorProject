using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EagleConnect.Services;
using EagleConnect.Models;
using System.ComponentModel.DataAnnotations;

namespace EagleConnect.Pages.Organizations;

[Authorize]
public class CreatePostModel : PageModel
{
    private readonly IStudentOrganizationService _organizationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreatePostModel(
        IStudentOrganizationService organizationService,
        UserManager<ApplicationUser> userManager)
    {
        _organizationService = organizationService;
        _userManager = userManager;
    }

    public StudentOrganization Organization { get; set; } = null!;
    public ApplicationUser CurrentUser { get; set; } = null!;

    [BindProperty]
    public PostInput Input { get; set; } = new();

    public class PostInput
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        [StringLength(5000, ErrorMessage = "Content cannot exceed 5000 characters")]
        public string Content { get; set; } = string.Empty;

        public bool IsPinned { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        // Only moderator or admin can create posts
        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        Organization = org;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        if (CurrentUser == null)
        {
            return RedirectToPage("/Account/Login");
        }

        var org = await _organizationService.GetOrganizationByIdAsync(id);
        if (org == null)
        {
            return NotFound();
        }

        var isAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
        if (org.ModeratorId != CurrentUser.Id && !isAdmin)
        {
            return Forbid();
        }

        Organization = org;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var post = new OrganizationPost
        {
            OrganizationId = id,
            AuthorId = CurrentUser.Id,
            Title = Input.Title,
            Content = Input.Content,
            IsPinned = Input.IsPinned,
            IsActive = true
        };

        await _organizationService.CreatePostAsync(post);
        TempData["SuccessMessage"] = "Post created successfully.";

        return RedirectToPage("/Organizations/View", new { id });
    }
}

