using Teachers.Core.Entities;

namespace Teachers.Core.IRepository;

public interface ITeacherSubjectRepository : IGenericRepository<TeacherSubject>
{
    Task<IReadOnlyList<TeacherSubject>?> GetTeacherSubjects(string teacherId);
}