using AutoMapper;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Response.FriendDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class FriendServices : IFriendServices
{
    private readonly IFriendRepository _friendRepository;
    private readonly IMapper _mapper;

    public FriendServices(IFriendRepository friendRepository, IMapper mapper)
    {
        _friendRepository = friendRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AddFriendResponseDto>> AddFriend(AddFriendRequestDto addFriendRequestDto)
    {
        var addFriendResponse = new ServiceResponse<AddFriendResponseDto>()
        {
            Data = new AddFriendResponseDto()
        };
        try
        {
            var friend = _mapper.Map<Friend>(addFriendRequestDto);
            var result = await _friendRepository.AddAsync(friend);
            if (friend != null)
            {
                addFriendResponse.Data = _mapper.Map<AddFriendResponseDto>(result);
                addFriendResponse.Messages.Add("Friend added successfully");
                return addFriendResponse;
            }

            addFriendResponse.Error.Add("Friend not added");
            addFriendResponse.Success = false;
            return addFriendResponse;
        }
        catch (Exception e)
        {
            addFriendResponse.Error.Add(e.Message);
            addFriendResponse.Success = false;
            return addFriendResponse;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteFriend(string friendId, string studentId)
    {
        var deleteFriendResponse = new ServiceResponse<bool>();
        try
        {
            var friend = await _friendRepository.GetByIdAsync(friendId);
            if (friend != null)
            {
                var result = await _friendRepository.DeleteFriend(friendId, studentId);
                if (result)
                {
                    deleteFriendResponse.Data = true;
                    deleteFriendResponse.Messages.Add("Friend deleted successfully");
                    return deleteFriendResponse;
                }

                deleteFriendResponse.Error.Add("Friend not deleted");
                deleteFriendResponse.Success = false;
                return deleteFriendResponse;
            }

            deleteFriendResponse.Error.Add("Friend not found");
            deleteFriendResponse.Success = false;
            return deleteFriendResponse;
        }
        catch (Exception e)
        {
            deleteFriendResponse.Error.Add(e.Message);
            deleteFriendResponse.Success = false;
            return deleteFriendResponse;
        }
    }

    public async Task<ServiceResponse<List<GetStudentFriendResponseDto>>> GetFriends(string studentId)
    {
        var getStudentFriendResponse = new ServiceResponse<List<GetStudentFriendResponseDto>>();
        try
        {
            var studentFriends = await _friendRepository.GetStudentFriend(studentId);
            if (studentFriends == null)
            {
                getStudentFriendResponse.Error.Add("Friends not found");
                getStudentFriendResponse.Success = false;
                return getStudentFriendResponse;
            }

            getStudentFriendResponse.Data = _mapper.Map<List<GetStudentFriendResponseDto>>(studentFriends);
            getStudentFriendResponse.Messages.Add("Friends found");
            return getStudentFriendResponse;
        }
        catch (Exception e)
        {
            getStudentFriendResponse.Error.Add(e.Message);
            getStudentFriendResponse.Success = false;
            return getStudentFriendResponse;
        }
    }
}