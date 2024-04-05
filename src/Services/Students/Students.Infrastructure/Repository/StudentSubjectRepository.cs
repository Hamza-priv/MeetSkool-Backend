using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class StudentSubjectRepository : GenericRepository<StudentSubject>, IStudentSubjectsRepository
{
    protected StudentSubjectRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
    }
}