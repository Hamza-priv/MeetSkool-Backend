using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Messages;
using Chat.Application.Services.Interface;
using Chat.Core.IRepository;

namespace Chat.Application.Services.Implementation;

public class MessageServices : IMessageServices
{
    public async Task<List<GetUserConversationResponseDto>> GetUserConversation(GetUserConversationRequestDto userConversationRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetUserGroupMessagesResponseDto>> GetGroupMessages(string groupId)
    {
        throw new NotImplementedException();
    }
}