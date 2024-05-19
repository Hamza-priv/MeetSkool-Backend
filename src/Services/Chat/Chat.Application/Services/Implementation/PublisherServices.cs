using AutoMapper;
using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Services.Interface;
using Contracts;
using MassTransit;

namespace Chat.Application.Services.Implementation;

public class PublisherServices : IPublisherServices
{
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public PublisherServices(IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task AddGroupMembers(AddMemberInGroupRequestDto addMember)
    {
        try
        {
            var memberToAdd = _mapper.Map<AddMemberInGroupEvent>(addMember);
            await _publishEndpoint.Publish(memberToAdd, cancellationToken: default);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SaveGroup()
    {
        throw new NotImplementedException();
    }

    public async Task SaveConversationMessage()
    {
        throw new NotImplementedException();
    }

    public async Task SaveGroupMessage()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveGroupMember(RemoveMemberFromGroupRequestDto removeMember)
    {
        try
        {
            var memberToRemove = _mapper.Map<RemoveMemberFromGroupEvent>(removeMember);
            await _publishEndpoint.Publish(memberToRemove, cancellationToken: default);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}