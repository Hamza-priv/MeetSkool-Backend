using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface IStudentServices
{
    Task<ServiceResponse<AddStudentResponseDto>> AddStudent(AddStudentRequestDto studentDto);
    Task<ServiceResponse<UpdateStudentResponseDto>> UpdateStudent(UpdateStudentRequestDto updateStudentDto);
    Task<ServiceResponse<bool>> DeleteStudent(string id);

}