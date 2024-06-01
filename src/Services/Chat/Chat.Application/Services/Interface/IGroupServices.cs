using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Response.Groups;
using Chat.Application.ServiceResponse;

namespace Chat.Application.Services.Interface;

public interface IGroupServices
{
    Task<ServiceResponse<List<GetUserGroupResponseDto>>> GetUserGroups(string userId);
    Task AddGroupMembers(AddMemberInGroupRequestDto addMember);
    Task SaveGroup(CreateGroupRequestDto createGroup);
    Task RemoveGroupMember(RemoveMemberFromGroupRequestDto removeMember);
}