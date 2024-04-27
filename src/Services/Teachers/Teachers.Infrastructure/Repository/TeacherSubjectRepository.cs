using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class TeacherSubjectRepository : GenericRepository<TeacherSubject>, ITeacherSubjectRepository
{
    private readonly TeacherDbContext _teacherDbContext;

    public TeacherSubjectRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<IReadOnlyList<TeacherSubject>?> GetTeacherSubjects(string teacherId)
    {
        try
        {
            var getTeacherSubjects = await _teacherDbContext.TeacherSubjects.Where(s => s.TeacherId == teacherId)
                .ToListAsync();
            return getTeacherSubjects.Count > 0 ? getTeacherSubjects : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}