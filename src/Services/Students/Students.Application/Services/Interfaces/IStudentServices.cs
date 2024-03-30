using Students.Application.DTOS.Response.StudentDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface IStudentServices
{
    Task<ServiceResponse<AddStudentResponseDto>> AddStudent();
    Task<ServiceResponse<UpdateStudentResponseDto>> UpdateStudent();
    Task<ServiceResponse<bool>> DeleteStudent();
}