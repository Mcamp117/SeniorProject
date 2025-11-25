using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EagleConnect.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a subject")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your message")]
        [StringLength(5000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 5000 characters")]
        public string Message { get; set; } = string.Empty;
    }

    public void OnGet()
    {
        // Pre-fill email if user is logged in
        if (User.Identity?.IsAuthenticated == true)
        {
            Input.Email = User.Identity.Name ?? string.Empty;
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // TODO: Implement actual email sending or database storage
        // For now, just show a success message
        
        // Example of what you might want to do:
        // - Save to database for admin review
        // - Send email notification to support team
        // - Send confirmation email to user

        TempData["SuccessMessage"] = "Thank you for your message! We'll get back to you within 1-2 business days.";
        
        return RedirectToPage();
    }
}

