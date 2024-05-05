using Teachers.Application.DTOS.Request.TeacherDto;
using Teachers.Application.DTOS.Response.TeacherDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface ITeacherServices
{
    Task<ServiceResponse<AddTeacherResponseDto>> AddTeacher(AddTeacherRequestDto teacherDto);
    Task<ServiceResponse<UpdateTeacherResponseDto>> UpdateTeacher(UpdateTeacherRequestDto updateTeacherDto);
    Task<ServiceResponse<bool>> DeleteTeacher(string teacherId);
    Task<ServiceResponse<GetAllInfoOfTeacherResponseDto>> GetAllInfoOfTeacher(string id);
    Task<ServiceResponse<List<GetTeacherListResponseDto>>> GetAllTeachers(string? searchTerm, int page, int pageSize);
}