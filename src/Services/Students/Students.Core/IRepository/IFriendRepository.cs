using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface IFriendRepository : IGenericRepository<Friend>
{
    Task<bool> DeleteFriend(string friendId, string studentId);
    Task<List<Friend>?> GetStudentFriend(string studentId);
}