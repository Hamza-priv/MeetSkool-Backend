using Teachers.Core.Entities;

namespace Teachers.Core.IRepository;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<List<Teacher>> SearchTeacher(string? searchTerm);
}