using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Request.Messages;

namespace Chat.Application.Services.Interface;

public interface IPublisherServices
{
    Task AddGroupMembers(AddMemberInGroupRequestDto addMember);
    Task SaveGroup(CreateGroupRequestDto createGroup);
    Task SaveConversationMessage(AddConversationMessageRequestDto conversationMessage);
    Task SaveGroupMessage(AddGroupMessageRequestDto groupMessage);
    Task RemoveGroupMember(RemoveMemberFromGroupRequestDto removeMember);
}