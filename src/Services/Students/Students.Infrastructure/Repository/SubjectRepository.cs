using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
    }
}