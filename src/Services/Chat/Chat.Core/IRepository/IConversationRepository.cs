using Chat.Core.Models;

namespace Chat.Core.IRepository;

public interface IConversationRepository : IGenericRepository<Conversations>
{
    Task<List<Conversations>> GetByUserConversation(string userId);
}