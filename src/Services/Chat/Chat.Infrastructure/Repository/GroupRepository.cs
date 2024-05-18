using Chat.Core.IRepository;
using Chat.Core.Models;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repository;

public class GroupRepository : GenericRepository<Groups>, IGroupRepository
{
    private readonly ChatDbContext _chatDbContext;

    protected GroupRepository(ChatDbContext chatDbContext) : base(chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<List<Groups>> GetUserGroups(string userId)
    {
        try
        {
            return await _chatDbContext.Groups
                .Where(group =>
                    group.GroupMembers != null && group.GroupMembers.Any(member => member.GroupMemberId == userId))
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}