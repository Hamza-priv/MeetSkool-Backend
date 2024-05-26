using Chat.Core.IRepository;
using Chat.Core.Models;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repository;

public class ConversationRepository : GenericRepository<Conversations>, IConversationRepository
{
    private readonly ChatDbContext _chatDbContext;

    public ConversationRepository(ChatDbContext chatDbContext) : base(chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<List<Conversations>> GetByUserConversation(string userId)
    {
        try
        {
            return await _chatDbContext.Conversations
                .Where(x => x.UserId == userId || x.ParticipantId == userId)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}