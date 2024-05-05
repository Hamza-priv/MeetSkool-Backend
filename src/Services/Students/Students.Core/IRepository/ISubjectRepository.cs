using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface ISubjectRepository : IGenericRepository<Subject>
{
    Task<List<Subject>> SearchSubjects(string? searchTerm);
}