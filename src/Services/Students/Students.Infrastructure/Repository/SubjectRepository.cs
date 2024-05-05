using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    private readonly StudentDbContext _studentDbContext;

    public SubjectRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<List<Subject>> SearchSubjects(string? searchTerm)
    {
        try
        {
            if (string.IsNullOrEmpty(searchTerm)) return await _studentDbContext.Subjects.ToListAsync();
            var subjects =
                await _studentDbContext.Subjects.Where(s => s.SubjectName != null && s.SubjectName.Contains(searchTerm))
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