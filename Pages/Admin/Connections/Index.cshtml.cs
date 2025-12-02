using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EagleConnect.Services;
using EagleConnect.Models;
using EagleConnect.Data;

namespace EagleConnect.Pages.Admin.Connections;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IConnectionService _connectionService;
    private readonly ApplicationDbContext _context;

    public IndexModel(IConnectionService connectionService, ApplicationDbContext context)
    {
        _connectionService = connectionService;
        _context = context;
    }

    public IList<Connection> Connections { get; set; } = new List<Connection>();

    public async Task OnGetAsync()
    {
        // Get all connections directly from the database
        Connections = await _context.Connections
            .Include(c => c.User1)
            .Include(c => c.User2)
            .Include(c => c.RequestedBy)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _connectionService.DeleteConnectionAsync(id);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAcceptAsync(int id)
    {
        var connection = await _connectionService.GetConnectionByIdAsync(id);
        if (connection != null && connection.RequestedById != null)
        {
            // Get the recipient (the user who is not the requester)
            var recipientId = connection.User1Id == connection.RequestedById 
                ? connection.User2Id 
                : connection.User1Id;
            
            await _connectionService.AcceptConnectionAsync(id, recipientId);
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeclineAsync(int id)
    {
        var connection = await _connectionService.GetConnectionByIdAsync(id);
        if (connection != null && connection.RequestedById != null)
        {
            // Get the recipient (the user who is not the requester)
            var recipientId = connection.User1Id == connection.RequestedById 
                ? connection.User2Id 
                : connection.User1Id;
            
            await _connectionService.DeclineConnectionAsync(id, recipientId);
        }
        return RedirectToPage();
    }
}

