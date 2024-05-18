using Chat.Core.Models;

namespace Chat.Core.IRepository;

public interface IGroupRepository : IGenericRepository<Groups>
{
    Task<List<Groups>> GetUserGroups(string userId);
}