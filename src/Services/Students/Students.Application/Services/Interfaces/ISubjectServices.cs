using Students.Application.DTOS.Response.SubjectDto;

namespace Students.Application.Services.Interfaces;

public interface ISubjectServices
{
    Task<GetSubjectResponseDto> GetSubject(string subjectId);
}