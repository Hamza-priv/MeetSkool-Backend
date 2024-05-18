using Chat.Application.Dtos.Response.Groups;

namespace Chat.Application.Services.Interface;

public interface IGroupServices
{
    Task<List<GetUserGroupResponseDto>> GetUserGroups(string userId);
}