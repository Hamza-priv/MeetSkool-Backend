using Chat.Application.Services.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Application.Services.Implementation;

public sealed class ChatServices : Hub<IChatServices>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId)
            .UserConnected("Your are connected to our system " + $"{Context.ConnectionId}");
    }

    public async Task CreateGroup(string groupId, string ownerId, string ownerName)
    {
        await Groups.AddToGroupAsync(ownerId, groupId);
        await Clients.Group(groupId).AddUserToGroup($"{ownerName} " + "has created this group");
    }

    public async Task AddUserToGroup(string groupId, string userId, string userName)
    {
        await Groups.AddToGroupAsync(userId, groupId);
        await Clients.Group(groupId).AddUserToGroup($"{userName}" + "has joined");
    }

    public async Task RemoveUserFromGroup(string groupId, string userId, string userName)
    {
        await Groups.RemoveFromGroupAsync(userId, groupId);
        await Clients.Group(groupId).RemoveUserFromGroup($"{userName}" + "has been removed");
    }

    public async Task SendMessageToGroup(string groupId, string message)
    {
        await Clients.Group(groupId).SendMessageToGroup(message);
    }

    public async Task SendMessageToUser(string receiverId, string senderId, string message)
    {
        await Clients.Client(receiverId).SendMessageToUser(senderId, message);
    }
}