using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface IStudentSubjectsRepository : IGenericRepository<StudentSubject>
{
    Task<IReadOnlyList<StudentSubject>?> GetStudentSubjects(string studentId);
}