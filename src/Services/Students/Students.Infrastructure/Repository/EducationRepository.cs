using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class EducationRepository : GenericRepository<Education>, IEducationRepository
{
    private readonly  StudentDbContext _studentDbContext;
    protected EducationRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<Education?> GetStudentEducation(string studentId)
    {
        try
        {
            var studentEducation  = await _studentDbContext.Educations.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            return studentEducation ?? null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}