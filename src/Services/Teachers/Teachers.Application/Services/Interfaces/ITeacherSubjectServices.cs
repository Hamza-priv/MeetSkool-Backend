using Teachers.Application.DTOS.Request.TeacherSubjectDto;
using Teachers.Application.DTOS.Response.TeacherSubjectDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface ITeacherSubjectServices
{
    Task<ServiceResponse<AddTeacherSubjectResponseDto>> AddTeacherSubject(
        AddTeacherSubjectRequestDto addTeacherSubjectRequestDto);

    Task<ServiceResponse<List<GetTeacherSubjectResponseDto>>> GetTeacherSubject(
        string teacherId);
}