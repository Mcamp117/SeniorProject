using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EagleConnect.Models;
using EagleConnect.Services;

namespace EagleConnect.Pages
{
    [Authorize]
    public class ConnectionsModel : PageModel
    {
        private readonly IConnectionService _connectionService;
        private readonly IMessageService _messageService;
        private readonly AuthService _authService;
        private readonly IUserService _userService;

        public ConnectionsModel(
            IConnectionService connectionService,
            IMessageService messageService,
            AuthService authService,
            IUserService userService)
        {
            _connectionService = connectionService;
            _messageService = messageService;
            _authService = authService;
            _userService = userService;
        }

        public ApplicationUser? CurrentUser { get; set; }
        public List<Connection> AcceptedConnections { get; set; } = new();
        public List<Connection> PendingConnections { get; set; } = new();
        public Connection? SelectedConnection { get; set; }
        public List<Message> Messages { get; set; } = new();
        public int? SelectedConnectionId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? connectionId = null)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            AcceptedConnections = await _connectionService.GetUserConnectionsAsync(CurrentUser.Id);
            PendingConnections = await _connectionService.GetPendingConnectionsAsync(CurrentUser.Id);

            if (connectionId.HasValue)
            {
                SelectedConnection = await _connectionService.GetConnectionByIdAsync(connectionId.Value);
                if (SelectedConnection != null && 
                    (SelectedConnection.User1Id == CurrentUser.Id || SelectedConnection.User2Id == CurrentUser.Id))
                {
                    SelectedConnectionId = connectionId.Value;
                    Messages = await _messageService.GetMessagesAsync(connectionId.Value, null, 50);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostConnectAsync(string userId)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                await _connectionService.CreateConnectionAsync(CurrentUser.Id, userId);
                TempData["SuccessMessage"] = "Connection request sent.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error sending connection request: {ex.Message}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int connectionId)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                await _connectionService.AcceptConnectionAsync(connectionId, CurrentUser.Id);
                TempData["SuccessMessage"] = "Connection accepted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error accepting connection: {ex.Message}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeclineAsync(int connectionId)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                await _connectionService.DeclineConnectionAsync(connectionId, CurrentUser.Id);
                TempData["SuccessMessage"] = "Connection declined.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error declining connection: {ex.Message}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int connectionId)
        {
            CurrentUser = await _authService.GetCurrentUserAsync(User);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                // Verify the user is part of the connection before deleting
                var connection = await _connectionService.GetConnectionByIdAsync(connectionId);
                if (connection != null && 
                    (connection.User1Id == CurrentUser.Id || connection.User2Id == CurrentUser.Id))
                {
                    await _connectionService.DeleteConnectionAsync(connectionId);
                    TempData["SuccessMessage"] = "Connection deleted.";
                }
                else
                {
                    TempData["ErrorMessage"] = "You don't have permission to delete this connection.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting connection: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}

