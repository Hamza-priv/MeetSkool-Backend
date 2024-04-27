using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
    }
}