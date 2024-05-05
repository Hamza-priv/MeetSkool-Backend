using Teachers.Core.Entities;

namespace Teachers.Core.IRepository;

public interface ISubjectRepository : IGenericRepository<Subject>
{
    Task<List<Subject>> SearchSubjects(string? searchTerm);
}