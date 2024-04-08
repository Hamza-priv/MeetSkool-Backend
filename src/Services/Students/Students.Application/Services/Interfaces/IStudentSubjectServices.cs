using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Application.DTOS.Response.StudentSubjectDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface IStudentSubjectServices
{
    Task<ServiceResponse<AddStudentSubjectResponseDto>> AddStudentSubject(
        AddStudentSubjectRequestDto addStudentSubjectRequestDto);

    Task<ServiceResponse<List<GetStudentSubjectResponseDto>>> GetStudentSubject(
        string studentId);
}