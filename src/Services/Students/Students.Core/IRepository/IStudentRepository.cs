using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface IStudentRepository : IGenericRepository<Student>
{ 
    Task<List<Student>> SearchStudents(string? searchTerm);
}