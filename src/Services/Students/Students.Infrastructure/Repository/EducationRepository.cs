using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class EducationRepository : GenericRepository<Education>, IEducationRepository
{
    protected EducationRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
    }
}