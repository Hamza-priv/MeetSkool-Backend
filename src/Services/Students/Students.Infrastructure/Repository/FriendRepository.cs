using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class FriendRepository : GenericRepository<Friend>, IFriendRepository
{
    private readonly StudentDbContext _studentDbContext;

    public FriendRepository(StudentDbContext studentDbContext) : base(studentDbContext)
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

    public async Task<List<Friend>?> GetStudentFriend(string studentId)
    {
        try
        {
            var studentFriend = await _studentDbContext.Friends.Where(f => f.StudentId == studentId).ToListAsync();
            return studentFriend.Count <= 0 ? null : studentFriend;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Friend?> GetFriend(string friendId)
    {
        try
        {
            var friend = await _studentDbContext.Friends.Where(f => f.FriendId == friendId).FirstOrDefaultAsync();
            return friend ?? null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}