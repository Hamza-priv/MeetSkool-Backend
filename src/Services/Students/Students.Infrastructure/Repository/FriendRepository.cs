using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class FriendRepository : GenericRepository<Friend>, IFriendRepository
{
    private readonly StudentDbContext _studentDbContext;

    protected FriendRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<bool> DeleteFriend(string friendId, string studentId)
    {
        try
        {
            var friend =
                await _studentDbContext.Friends.FirstOrDefaultAsync(f =>
                    f.StudentId == studentId && f.FriendId == friendId);
            if (friend == null) return false;
            _studentDbContext.Entry(friend).State = EntityState.Deleted;
            await _studentDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}