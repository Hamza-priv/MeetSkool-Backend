using AutoMapper;
using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Response.Groups;
using Chat.Application.ServiceResponse;
using Chat.Application.Services.Interface;
using Chat.Core.IRepository;
using Chat.Core.Models;

namespace Chat.Application.Services.Implementation;

public class GroupServices : IGroupServices
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupServices(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetUserGroupResponseDto>>> GetUserGroups(string userId)
    {
        var userGroupResponse = new ServiceResponse<List<GetUserGroupResponseDto>>();
        try
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var userGroupsList = await _groupRepository.GetUserGroups(userId);
                if (userGroupsList.Count > 0)
                {
                    userGroupResponse.Data = _mapper.Map<List<GetUserGroupResponseDto>>(userGroupsList);
                    userGroupResponse.Messages.Add("User Groups Found");
                    return userGroupResponse;
                }

                userGroupResponse.Error.Add("No Group Found");
                userGroupResponse.Success = false;
                return userGroupResponse;
            }

            userGroupResponse.Error.Add("User Id is empty");
            userGroupResponse.Success = false;
            return userGroupResponse;
        }
        catch (Exception e)
        {
            userGroupResponse.Error.Add(e.Message);
            userGroupResponse.Success = false;
            return userGroupResponse;
        }
    }

    public async Task AddGroupMembers(AddMemberInGroupRequestDto addMember)
    {
        try
        {
            if (addMember is { GroupId: not null, MemberName: not null, MemberId: not null })
                await _groupRepository.AddMemberToGroup(addMember.MemberId, addMember.GroupId,
                    addMember.MemberName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SaveGroup(CreateGroupRequestDto createGroup)
    {
        try
        {
            var group = _mapper.Map<Groups>(createGroup);
            await _groupRepository.AddAsync(group);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task RemoveGroupMember(RemoveMemberFromGroupRequestDto removeMember)
    {
        try
        {
            if (removeMember is { GroupId: not null, MemberId: not null })
                await _groupRepository.RemoveMemberFromGroup(removeMember.MemberId, removeMember.GroupId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}