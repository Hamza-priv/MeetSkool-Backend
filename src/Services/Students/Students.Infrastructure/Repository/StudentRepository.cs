using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    protected StudentRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
    }
}