using Teachers.Application.DTOS.Response.SubjectDto;

namespace Teachers.Application.Services.Interfaces;

public interface ISubjectServices
{
    Task<GetSubjectResponseDto?> GetSubject(Guid subjectId);
}