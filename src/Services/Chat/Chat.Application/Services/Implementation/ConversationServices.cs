using AutoMapper;
using Chat.Application.Dtos.Response.Conversation;
using Chat.Application.ServiceResponse;
using Chat.Application.Services.Interface;
using Chat.Core.IRepository;

namespace Chat.Application.Services.Implementation;

public class ConversationServices : IConversationServices
{
    private readonly IConversationRepository _conversationRepository;
    private readonly IMapper _mapper;

    public ConversationServices(IConversationRepository conversationRepository, IMapper mapper)
    {
        _conversationRepository = conversationRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetUserConversationListResponseDto>>> GetUserConversationList(string userId)
    {
        var conversationResponse = new ServiceResponse<List<GetUserConversationListResponseDto>>();
        try
        {
            var list = await _conversationRepository.GetByUserConversation(userId);
            if (list.Count > 0)
            {
                conversationResponse.Data = _mapper.Map<List<GetUserConversationListResponseDto>>(list);
                conversationResponse.Messages.Add("Conversations found");
                return conversationResponse;
            }

            conversationResponse.Error.Add("No conversations found");
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
}