using Chat.Application.Dtos.Response.Groups;
using Chat.Application.Services.Interface;

namespace Chat.Application.Services.Implementation;

public class GroupServices : IGroupServices
{
    public async Task<List<GetUserGroupResponseDto>> GetUserGroups(string userId)
    {
        throw new NotImplementedException();
    }
}