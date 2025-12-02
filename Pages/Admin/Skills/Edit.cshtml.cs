using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Skills;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
    {
        private readonly ISkillService _skillService;

        public EditModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [BindProperty]
        public Skill Skill { get; set; } = new Skill();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            Skill = skill;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _skillService.UpdateSkillAsync(Skill);
            return RedirectToPage("./Index");
        }
    }
