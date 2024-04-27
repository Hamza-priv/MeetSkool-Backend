using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class EducationRepository : GenericRepository<Education>, IEducationRepository
{
    private readonly TeacherDbContext _teacherDbContext;

    public EducationRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<Education?> GetTeacherEducation(string teacherId)
    {
        try
        {
            var teacherEducation = await _teacherDbContext.Educations.Where(x => x.TeacherId == teacherId)
                .FirstOrDefaultAsync();
            return teacherEducation ?? null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}