using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Pages.Posts;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IConnectionPostService _postService;

    public IndexModel(IConnectionPostService postService)
    {
        _postService = postService;
    }

    public IList<ConnectionPost> AllPosts { get; set; } = new List<ConnectionPost>();

    public async Task OnGetAsync()
    {
        AllPosts = await _postService.GetAllConnectionPostsAsync();
    }
}
