using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using EagleConnect.Services;
using EagleConnect.Models;

namespace EagleConnect.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IConnectionService _connectionService;
        private readonly IStudentOrganizationService _organizationService;

        public ChatHub(
            IMessageService messageService, 
            IConnectionService connectionService,
            IStudentOrganizationService organizationService)
        {
            _messageService = messageService;
            _connectionService = connectionService;
            _organizationService = organizationService;
        }

        // ===== Direct Message Methods =====
        
        public async Task SendMessage(int connectionId, string content)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
            {
                await Clients.Caller.SendAsync("Error", "User not authenticated");
                return;
            }

            // Verify connection exists and user is part of it
            var connection = await _connectionService.GetConnectionByIdAsync(connectionId);
            if (connection == null || (connection.User1Id != userId && connection.User2Id != userId))
            {
                await Clients.Caller.SendAsync("Error", "Connection not found or unauthorized");
                return;
            }

            // Save message to database
            var message = await _messageService.SendMessageAsync(connectionId, userId, content);

            // Get the other user's ID
            var otherUserId = connection.User1Id == userId ? connection.User2Id : connection.User1Id;

            // Send to both users
            await Clients.User(userId).SendAsync("ReceiveMessage", new
            {
                id = message.Id,
                connectionId = message.ConnectionId,
                senderId = message.SenderId,
                senderName = message.Sender?.FirstName + " " + message.Sender?.LastName,
                content = message.Content,
                sentAt = message.SentAt,
                isRead = message.IsRead
            });

            await Clients.User(otherUserId).SendAsync("ReceiveMessage", new
            {
                id = message.Id,
                connectionId = message.ConnectionId,
                senderId = message.SenderId,
                senderName = message.Sender?.FirstName + " " + message.Sender?.LastName,
                content = message.Content,
                sentAt = message.SentAt,
                isRead = message.IsRead
            });

            // Notify other user of new message
            await Clients.User(otherUserId).SendAsync("NewMessageNotification", connectionId);
        }

        public async Task JoinConnection(int connectionId)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Verify connection exists and user is part of it
            var connection = await _connectionService.GetConnectionByIdAsync(connectionId);
            if (connection != null && (connection.User1Id == userId || connection.User2Id == userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"connection_{connectionId}");
                
                // Mark messages as read
                var messages = await _messageService.GetMessagesAsync(connectionId);
                foreach (var message in messages.Where(m => m.SenderId != userId && !m.IsRead))
                {
                    await _messageService.MarkMessageAsReadAsync(message.Id, userId);
                }
            }
        }

        public async Task LeaveConnection(int connectionId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"connection_{connectionId}");
        }

        // ===== Organization Group Chat Methods =====

        public async Task SendOrganizationMessage(int organizationId, string content)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
            {
                await Clients.Caller.SendAsync("Error", "User not authenticated");
                return;
            }

            // Verify user is a member of the organization
            var isMember = await _organizationService.IsMemberAsync(organizationId, userId);
            var isModerator = await _organizationService.IsModeratorAsync(organizationId, userId);
            
            if (!isMember && !isModerator)
            {
                await Clients.Caller.SendAsync("Error", "You are not a member of this organization");
                return;
            }

            // Save message to database
            var message = await _organizationService.SendMessageAsync(organizationId, userId, content);

            // Send to all members in the organization group
            await Clients.Group($"organization_{organizationId}").SendAsync("ReceiveOrganizationMessage", new
            {
                id = message.Id,
                organizationId = message.OrganizationId,
                senderId = message.SenderId,
                senderName = message.Sender?.FirstName + " " + message.Sender?.LastName,
                content = message.Content,
                sentAt = message.SentAt
            });
        }

        public async Task JoinOrganization(int organizationId)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Verify user is a member of the organization
            var isMember = await _organizationService.IsMemberAsync(organizationId, userId);
            var isModerator = await _organizationService.IsModeratorAsync(organizationId, userId);
            
            if (isMember || isModerator)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"organization_{organizationId}");
                
                // Notify others that user joined (optional)
                await Clients.OthersInGroup($"organization_{organizationId}").SendAsync("UserJoinedOrganizationChat", new
                {
                    organizationId,
                    userId
                });
            }
        }

        public async Task LeaveOrganization(int organizationId)
        {
            var userId = Context.UserIdentifier;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"organization_{organizationId}");
            
            // Notify others that user left (optional)
            await Clients.OthersInGroup($"organization_{organizationId}").SendAsync("UserLeftOrganizationChat", new
            {
                organizationId,
                userId
            });
        }

        public async Task NotifyTypingInOrganization(int organizationId)
        {
            var userId = Context.UserIdentifier;
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            await Clients.OthersInGroup($"organization_{organizationId}").SendAsync("UserTypingInOrganization", new
            {
                organizationId,
                userId
            });
        }

        // ===== Connection Lifecycle =====

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
