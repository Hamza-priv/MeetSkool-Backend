using Teachers.Application.DTOS.Request.TeacherDto;
using Teachers.Application.DTOS.Response.TeacherDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface ITeacherServices
{
    Task<ServiceResponse<AddTeacherResponseDto>> AddStudent(AddTeacherRequestDto teacherDto);
    Task<ServiceResponse<UpdateTeacherResponseDto>> UpdateStudent(UpdateTeacherRequestDto updateTeacherDto);
    Task<ServiceResponse<bool>> DeleteStudent(string id);
    Task<ServiceResponse<GetAllInfoOfTeacherResponseDto>> GetAllInfoOfStudent(string id);
    Task<ServiceResponse<GetTeacherListResponseDto>> GetAllStudents(string? searchTerm, int page, int pageSize);
}