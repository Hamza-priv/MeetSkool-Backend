using Chat.Core.Models;

namespace Chat.Core.IRepository;

public interface IMessageRepository : IGenericRepository<Messages>
{
    Task<List<Messages>> GetConversationMessages(string senderId, string receiverId);
    Task<List<Messages>> GetGroupMessages(string groupId);
}