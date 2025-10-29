using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Admin.Skills;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
    {
        private readonly ISkillService _skillService;

        public IndexModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IList<Skill> Skills { get; set; } = new List<Skill>();

        public async Task OnGetAsync()
        {
            Skills = await _skillService.GetAllSkillsAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _skillService.DeleteSkillAsync(id);
            return RedirectToPage();
    }
}
