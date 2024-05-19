using AutoMapper;
using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Messages;
using Chat.Application.ServiceResponse;
using Chat.Application.Services.Interface;
using Chat.Core.IRepository;

namespace Chat.Application.Services.Implementation;

public class MessageServices : IMessageServices
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageServices(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetUserConversationResponseDto>>> GetUserConversation(
        GetUserConversationRequestDto userConversationRequestDto)
    {
        var conversationResponse = new ServiceResponse<List<GetUserConversationResponseDto>>();
        try
        {
            if (userConversationRequestDto is { SenderId: not null, ReceiverId: not null })
            {
                var conversationList = await _messageRepository.GetConversationMessages(
                    userConversationRequestDto.SenderId,
                    userConversationRequestDto.ReceiverId);
                if (conversationList.Count > 0)
                {
                    var sortedConversationList = conversationList.OrderBy(x => x.Date).ToList();
                    conversationResponse.Data =
                        _mapper.Map<List<GetUserConversationResponseDto>>(sortedConversationList);
                    conversationResponse.Messages.Add("Conversation found");
                    return conversationResponse;
                }

                conversationResponse.Error.Add("No conversation found");
                conversationResponse.Success = false;
                return conversationResponse;
            }

            conversationResponse.Error.Add("SenderId and ReceiverId are required");
            conversationResponse.Success = false;
            return conversationResponse;
        }
        catch (Exception e)
        {
            conversationResponse.Error.Add(e.Message);
            conversationResponse.Success = false;
            return conversationResponse;
        }
    }

    public async Task<ServiceResponse<List<GetUserGroupMessagesResponseDto>>> GetGroupMessages(string groupId)
    {
        var groupMessagesResponse = new ServiceResponse<List<GetUserGroupMessagesResponseDto>>();
        try
        {
            var groupMessages = await _messageRepository.GetGroupMessages(groupId);
            if (groupMessages.Count > 0)
            {
                var sortedGroupMessages = groupMessages.OrderBy(x => x.Date).ToList();
                groupMessagesResponse.Data =
                    _mapper.Map<List<GetUserGroupMessagesResponseDto>>(sortedGroupMessages);
                groupMessagesResponse.Messages.Add("Messages found");
                return groupMessagesResponse;
            }

            groupMessagesResponse.Error.Add("No messages found");
            groupMessagesResponse.Success = false;
            return groupMessagesResponse;
        }
        catch (Exception e)
        {
            groupMessagesResponse.Error.Add(e.Message);
            groupMessagesResponse.Success = false;
            return groupMessagesResponse;
        }
    }
}