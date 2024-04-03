using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Response.FriendDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface IFriendServices
{ 
    Task<ServiceResponse<AddFriendResponseDto>> AddFriend(AddFriendRequestDto addFriendRequestDto);
    Task<ServiceResponse<bool>> DeleteFriend(string friendId, string studentId);
}