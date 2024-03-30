using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class FriendRepository : GenericRepository<Friend>, IFriendRepository
{
    protected FriendRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
    }
}