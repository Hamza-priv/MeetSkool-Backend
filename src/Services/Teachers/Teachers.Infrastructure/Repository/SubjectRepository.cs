using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    private readonly TeacherDbContext _teacherDbContext;

    public SubjectRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<List<Subject>> SearchSubjects(string? searchTerm)
    {
        try
        {
            if (string.IsNullOrEmpty(searchTerm)) return await _teacherDbContext.Subjects.ToListAsync();
            var subjects =
                await _teacherDbContext.Subjects.Where(s => s.SubjectName != null && s.SubjectName.Contains(searchTerm))
                    .ToListAsync();
            return subjects;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}