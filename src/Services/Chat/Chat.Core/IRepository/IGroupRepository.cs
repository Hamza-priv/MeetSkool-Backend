using Chat.Core.Models;

namespace Chat.Core.IRepository;

public interface IGroupRepository : IGenericRepository<Groups>
{
    Task<List<Groups>> GetUserGroups(string userId);
    Task RemoveMemberFromGroup(string memberId, string groupId);
    Task AddMemberToGroup(string memberId, string groupId, string memberName);
    Task<int> TotalMembersInGroup(string groupId);
}