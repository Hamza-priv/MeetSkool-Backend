using Chat.Application.Dtos.Response.Groups;
using Chat.Application.ServiceResponse;

namespace Chat.Application.Services.Interface;

public interface IGroupServices
{
    Task<ServiceResponse<List<GetUserGroupResponseDto>>> GetUserGroups(string userId);
}