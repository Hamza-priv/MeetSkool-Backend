using Chat.Core.IRepository;
using Chat.Core.Models;
using Chat.Infrastructure.Data;

namespace Chat.Infrastructure.Repository;

public class UserConnectionRepository : GenericRepository<UserConnections>, IUserConnectionRepository
{
    public UserConnectionRepository(ChatDbContext chatDbContext) : base(chatDbContext)
    {
    }
}