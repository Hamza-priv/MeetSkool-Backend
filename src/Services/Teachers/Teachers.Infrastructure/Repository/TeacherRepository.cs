using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    private readonly TeacherDbContext _teacherDbContext;

    public TeacherRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<List<Teacher>> SearchTeacher(string? searchTerm)
    {
        try
        {
            if (string.IsNullOrEmpty(searchTerm)) return await _teacherDbContext.Teachers.ToListAsync();
            var teachers =
                await _teacherDbContext.Teachers.Where(s => s.TeacherName != null && s.TeacherName.Contains(searchTerm))
                    .ToListAsync();
            return teachers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}