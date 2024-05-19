using Chat.Application.Dtos.Request.Groups;

namespace Chat.Application.Services.Interface;

public interface IPublisherServices
{
    Task AddGroupMembers(AddMemberInGroupRequestDto addMember);
    Task SaveGroup();
    Task SaveConversationMessage();
    Task SaveGroupMessage();
    Task RemoveGroupMember(RemoveMemberFromGroupRequestDto removeMember);
}