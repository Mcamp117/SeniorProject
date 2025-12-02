using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Skills;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
    {
        private readonly ISkillService _skillService;

        public CreateModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [BindProperty]
        public Skill Skill { get; set; } = new Skill();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _skillService.CreateSkillAsync(Skill);
            return RedirectToPage("./Index");
        }
    }
