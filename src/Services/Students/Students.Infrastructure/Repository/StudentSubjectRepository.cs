using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class StudentSubjectRepository : GenericRepository<StudentSubject>, IStudentSubjectsRepository
{
    private readonly StudentDbContext _studentDbContext;

    public StudentSubjectRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<IReadOnlyList<StudentSubject>?> GetStudentSubjects(string studentId)
    {
        try
        {
            var studentSubjectList = await _studentDbContext.StudentSubjects.Where(s => s.StudentId == studentId)
                .ToListAsync();
            return studentSubjectList.Count > 0 ? studentSubjectList : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}