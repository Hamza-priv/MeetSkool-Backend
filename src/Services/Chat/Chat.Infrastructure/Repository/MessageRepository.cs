using Chat.Core.IRepository;
using Chat.Core.Models;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repository;

public class MessageRepository : GenericRepository<Messages>, IMessageRepository
{
    private readonly ChatDbContext _chatDbContext;

    public MessageRepository(ChatDbContext chatDbContext) : base(chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<List<Messages>> GetConversationMessages(string senderId, string receiverId)
    {
        try
        {
            return await _chatDbContext.Messages.Where(x => x.SenderId == senderId && x.ReceiverId == receiverId ||
                                                            x.SenderId == receiverId && x.ReceiverId == senderId)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Messages>> GetGroupMessages(string groupId)
    {
        try
        {
            return await _chatDbContext.Messages.Where(x => x.GroupId == groupId).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}