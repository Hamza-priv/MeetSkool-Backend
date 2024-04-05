using Students.Application.DTOS.Response.StudentSubjectDto;

namespace Students.Application.Services.Interfaces;

public interface IStudentSubjectServices
{
    Task<AddStudentSubjectResponseDto> AddStudentSubject(AddStudentSubjectResponseDto addStudentSubjectResponseDto);

    Task<List<GetStudentSubjectResponseDto>> GetStudentSubject(
        GetStudentSubjectResponseDto getStudentSubjectResponseDto);
}