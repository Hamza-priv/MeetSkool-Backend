using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class CommentRepository : GenericRepository<Comments>, ICommentRepository
{
    protected CommentRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
    }
}