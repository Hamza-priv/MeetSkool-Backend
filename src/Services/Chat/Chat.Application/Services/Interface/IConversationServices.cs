using Chat.Application.Dtos.Response.Conversation;
using Chat.Application.Dtos.Response.Messages;
using Chat.Application.ServiceResponse;

namespace Chat.Application.Services.Interface;

public interface IConversationServices
{
    Task<ServiceResponse<List<GetUserConversationListResponseDto>>> GetUserConversationList(string userId);
}