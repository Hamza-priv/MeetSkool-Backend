using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Response.EducationDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface IEducationServices
{ 
    Task<ServiceResponse<AddEducationResponseDto>> AddEducation(AddEducationRequestDto addEducationRequestDto); 
    Task<ServiceResponse<UpdateEducationResponseDto>> UpdateEducation(UpdateEducationRequestDto updateEducationRequestDto);
}