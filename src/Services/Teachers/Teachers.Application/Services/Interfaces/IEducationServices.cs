using Teachers.Application.DTOS.Request.EducationDto;
using Teachers.Application.DTOS.Response.EducationDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface IEducationServices
{
    Task<ServiceResponse<AddEducationResponseDto>> AddEducation(AddEducationRequestDto addEducationRequestDto);

    Task<ServiceResponse<UpdateEducationResponseDto>> UpdateEducation(
        UpdateEducationRequestDto updateEducationRequestDto);

    Task<ServiceResponse<GetTeacherEducationResponseDto>> GetTeacherEducation(string teacherId);
}