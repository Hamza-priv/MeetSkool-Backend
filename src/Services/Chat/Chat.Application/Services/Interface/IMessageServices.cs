using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Messages;
using Chat.Application.ServiceResponse;

namespace Chat.Application.Services.Interface;

public interface IMessageServices
{
    Task<ServiceResponse<List<GetUserConversationResponseDto>>> GetUserConversation(GetUserConversationRequestDto userConversationRequestDto);
    Task<ServiceResponse<List<GetUserGroupMessagesResponseDto>>> GetGroupMessages(string groupId);
    Task SaveGroupMessage(AddGroupMessageRequestDto groupMessage);
    Task SaveConversationMessage(AddConversationMessageRequestDto conversationMessage);


}