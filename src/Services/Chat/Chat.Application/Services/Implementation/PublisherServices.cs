using AutoMapper;
using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Services.Interface;
using Chat.Core.Models;
using Contracts;
using MassTransit;

namespace Chat.Application.Services.Implementation;

public class PublisherServices : IPublisherServices
{
    private readonly IMapper _mapper;
    private readonly IBus _publishEndpoint;

    public PublisherServices(IMapper mapper, IBus bus)
    {
        _mapper = mapper;
        _publishEndpoint = bus;
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

    public async Task SaveGroup(CreateGroupRequestDto createGroup)
    {
        try
        {
            var group = _mapper.Map<Groups>(createGroup);
            await _publishEndpoint.Publish(group, cancellationToken: default);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SaveConversationMessage(AddConversationMessageRequestDto conversationMessage)
    {
        try
        {
            var message = _mapper.Map<Messages>(conversationMessage);
            await _publishEndpoint.Publish(message, cancellationToken: default);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SaveGroupMessage(AddGroupMessageRequestDto groupMessage)
    {
        try
        {
            var message = _mapper.Map<Messages>(groupMessage);
            await _publishEndpoint.Publish(message);
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