using System.Runtime.CompilerServices;
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

    public async Task RemoveMemberFromGroup(string memberId, string groupId)
    {
        try
        {
            var group = await _chatDbContext.Groups.Include(groups => groups.GroupMembers)
                .FirstOrDefaultAsync(x => x.GroupId == groupId);
            if (group == null)
            {
                return;
            }

            if (group.GroupMembers == null)
            {
                return;
            }

            var memberToRemove = group.GroupMembers.FirstOrDefault(x => x.GroupMemberId == memberId);
            if (memberToRemove == null)
            {
                return;
            }

            group.GroupMembers.Remove(memberToRemove);
            await _chatDbContext.SaveChangesAsync();
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task AddMemberToGroup(string memberId, string groupId, string memberName)
    {
        try
        {
            var group = await _chatDbContext.Groups.Include(groups => groups.GroupMembers)
                .FirstOrDefaultAsync(x => x.GroupId == groupId);
            if (group == null)
            {
                return;
            }

            group.GroupMembers?.Add(new GroupMember
            {
                GroupMemberId = memberId, GroupMemberName = memberName, JoinedAt = DateTime.Now.ToLocalTime()
            });
            await _chatDbContext.SaveChangesAsync();
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> TotalMembersInGroup(string groupId)
    {
        try
        {
            var group = await _chatDbContext.Groups.Include(groups => groups.GroupMembers)
                .FirstOrDefaultAsync(x => x.GroupId == groupId);
            return group?.GroupMembers?.Count ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}