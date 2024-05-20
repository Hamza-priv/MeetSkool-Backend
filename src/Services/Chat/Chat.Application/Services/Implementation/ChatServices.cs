using Chat.Application.Services.Interface;
using Chat.Core.IRepository;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Application.Services.Implementation;

public sealed class ChatServices : Hub<IChatServices>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IPublisherServices _publisherServices;

    public ChatServices(IGroupRepository groupRepository, IPublisherServices publisherServices)
    {
        _groupRepository = groupRepository;
        _publisherServices = publisherServices;
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId)
            .UserConnected("Your are connected to our system " + $"{Context.ConnectionId}");
    }

    public async Task CreateGroup(string groupId, string ownerId, string ownerName, string groupName)
    {
        try
        {
            await Groups.AddToGroupAsync(ownerId, groupId);
            await Clients.Group(groupId).AddUserToGroup($"{ownerName} " + "has created this group");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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