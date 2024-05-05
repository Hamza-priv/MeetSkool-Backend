using Teachers.Application.DTOS.Response.SubjectDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface ISubjectServices
{
    Task<GetSubjectResponseDto?> GetSubject(Guid subjectId);
    Task<ServiceResponse<GetSubjectListResponseDto>> GetSearchedSubjects(string? searchTerm);
}