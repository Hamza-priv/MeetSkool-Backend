using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Messages;

namespace Chat.Application.Services.Interface;

public interface IMessageServices
{
    Task<List<GetUserConversationResponseDto>> GetUserConversation(GetUserConversationRequestDto userConversationRequestDto);
    Task<List<GetUserGroupMessagesResponseDto>> GetGroupMessages(string groupId);
}