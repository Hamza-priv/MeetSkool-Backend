using Teachers.Core.Entities;

namespace Teachers.Core.IRepository;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<Education?> GetTeacherEducation(string teacherId);
}