using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly StudentDbContext _studentDbContext;

    public StudentRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<List<Student>> SearchStudents(string? searchTerm)
    {
        try
        {
            if (string.IsNullOrEmpty(searchTerm)) return await _studentDbContext.Students.ToListAsync();
            var students =
                await _studentDbContext.Students.Where(s => s.StudentName != null && s.StudentName.Contains(searchTerm))
                    .ToListAsync();
            return students;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}