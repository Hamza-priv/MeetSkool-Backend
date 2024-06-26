using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Services.Interface;
using Chat.Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Application.Services.Implementation;

/*
[Authorize]
*/
public sealed class ChatServices : Hub<IChatServices>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMessageServices _messageServices;
    private readonly IGroupServices _groupServices;


    public ChatServices(IGroupRepository groupRepository, IMessageServices messageServices,
        IGroupServices groupServices)
    {
        _groupRepository = groupRepository;
        _messageServices = messageServices;
        _groupServices = groupServices;
    }

    public override async Task OnConnectedAsync()
    {
        try
        {
            // todo need to store connection Id in db

            await Clients.Client(Context.ConnectionId)
                .UserConnected("Your are connected to our system " + $"{Context.ConnectionId}");
            /*
            await Clients.Users(Context.UserIdentifier).UserConnected("Your are connected to our system " + $"{Context.ConnectionId}");
             */
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreateGroup(string groupId, string ownerId, string ownerName, string groupName)
    {
        try
        {
            await Groups.AddToGroupAsync(ownerId, groupId);
            await Clients.Group(groupId).AddUserToGroup($"{ownerName} " + "has created this group");
            

            var group = new CreateGroupRequestDto()
            {
                GroupId = groupId,
                GroupOwnerName = ownerName,
                GroupName = groupName
            };
            await _groupServices.SaveGroup(group);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task AddUserToGroup(string groupId, List<string> userId, string userName)
    {
        // todo publish method need to be corrected
        var members = await _groupRepository.TotalMembersInGroup(groupId);
        if (members < 5)
        {
            var task = userId.Select(user => Groups.AddToGroupAsync(user, groupId)).ToList();
            await Task.WhenAll(task);

            if (userId.Count > 6)
            {
                await Clients.Group(groupId).AddUserToGroup($"All users have joined");
                return;
            }

            await Clients.Group(groupId).AddUserToGroup($"User have joined");

            // Todo for adding it in database repo need to be built
        }

        await Clients.Group(groupId).AddUserToGroup($"Can not add more then 5 members");
    }

    public async Task RemoveUserFromGroup(string groupId, string userId, string userName)
    {
        await Groups.RemoveFromGroupAsync(userId, groupId);
        await Clients.Group(groupId).RemoveUserFromGroup($"{userName}" + "has been removed");


        var removeMember = new RemoveMemberFromGroupRequestDto()
        {
            MemberId = userId,
            GroupId = groupId
        };
        await _groupServices.RemoveGroupMember(removeMember);
    }

    public async Task SendMessageToGroup(string groupId, string message, string senderId, string senderName)
    {
        await Clients.Group(groupId).SendMessageToGroup(message);

        var groupMessage = new AddGroupMessageRequestDto()
        {
            GroupId = groupId,
            Message = message,
            SenderId = senderId,
            SenderName = senderName
        };

        await _messageServices.SaveGroupMessage(groupMessage);
    }

    
    //  for now receiverID is basically connectionId also senderId todo 
    public async Task SendMessageToUser(string receiverId, string senderId, string message, string senderName,
        string receiverName)
    {
        await Clients.Client(receiverId).SendMessageToUser(senderId, message);
        await Clients.User(Context.ConnectionId).SendMessageToUser(senderId, message);

        var conversationMessage = new AddConversationMessageRequestDto()
        {
            SenderName = senderName,
            SenderId = senderId,
            ReceiverId = receiverId,
            ReceiverName = receiverName,
            Message = message
        };
        
        await _messageServices.SaveConversationMessage(conversationMessage);
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        // todo
        return base.OnDisconnectedAsync(exception);
    }
}