using AutoMapper;
using Teachers.Application.DTOS.Request.EducationDto;
using Teachers.Application.DTOS.Response.EducationDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;

namespace Teachers.Application.Services.Implementation;

public class EducationServices : IEducationServices
{
    private readonly IEducationRepository _educationRepository;
    private readonly IMapper _mapper;

    public EducationServices(IEducationRepository educationRepository, IMapper mapper)
    {
        _educationRepository = educationRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AddEducationResponseDto>> AddEducation(
        AddEducationRequestDto addEducationRequestDto)
    {
        var addEducationResponse = new ServiceResponse<AddEducationResponseDto>()
        {
            Data = new AddEducationResponseDto()
        };
        try
        {
            var education = _mapper.Map<Education>(addEducationRequestDto);
            var result = await _educationRepository.AddAsync(education);
            if (result != null)
            {
                addEducationResponse.Data = _mapper.Map<AddEducationResponseDto>(result);
                addEducationResponse.Messages.Add("Education added successfully");
                return addEducationResponse;
            }

            addEducationResponse.Error.Add("Education not added");
            addEducationResponse.Success = false;
            return addEducationResponse;
        }
        catch (Exception e)
        {
            addEducationResponse.Error.Add(e.Message);
            addEducationResponse.Success = false;
            return addEducationResponse;
        }
    }

    public async Task<ServiceResponse<UpdateEducationResponseDto>> UpdateEducation(
        UpdateEducationRequestDto updateEducationRequestDto)
    {
        var updateEducationResponse = new ServiceResponse<UpdateEducationResponseDto>()
        {
            Data = new UpdateEducationResponseDto()
        };
        try
        {
            if (updateEducationRequestDto.TeacherId != null)
            {
                var dbEducation = await _educationRepository.GetTeacherEducation(updateEducationRequestDto.TeacherId);
                if (dbEducation is not null)
                {
                    var newEducation = _mapper.Map(dbEducation, updateEducationRequestDto);
                    var updatedEducation = _mapper.Map<Education>(newEducation);
                    var result = await _educationRepository.UpdateAsync(updatedEducation);
                    if (result is not null)
                    {
                        updateEducationResponse.Data = _mapper.Map<UpdateEducationResponseDto>(result);
                        updateEducationResponse.Messages.Add("Education updated successfully");
                        return updateEducationResponse;
                    }

                    updateEducationResponse.Error.Add("Education not updated");
                    updateEducationResponse.Success = false;
                    return updateEducationResponse;
                }

                updateEducationResponse.Error.Add("Education not found");
                updateEducationResponse.Success = false;
                return updateEducationResponse;
            }

            updateEducationResponse.Error.Add("EducationId is required");
            updateEducationResponse.Success = false;
            return updateEducationResponse;
        }
        catch (Exception e)
        {
            updateEducationResponse.Error.Add(e.Message);
            updateEducationResponse.Success = false;
            return updateEducationResponse;
        }
    }

    public async Task<ServiceResponse<GetTeacherEducationResponseDto>> GetTeacherEducation(string teacherId)
    {
        var getTeacherEducationResponse = new ServiceResponse<GetTeacherEducationResponseDto>()
        {
            Data = new GetTeacherEducationResponseDto()
        };
        try
        {
            var teacherEducation = await _educationRepository.GetTeacherEducation(teacherId);
            if (teacherEducation is not null)
            {
                getTeacherEducationResponse.Data = _mapper.Map<GetTeacherEducationResponseDto>(teacherEducation);
                getTeacherEducationResponse.Messages.Add("StudentEducationFound");
                return getTeacherEducationResponse;
            }

            getTeacherEducationResponse.Error.Add("StudentEducationNotFound");
            getTeacherEducationResponse.Success = false;
            return getTeacherEducationResponse;
        }
        catch (Exception e)
        {
            getTeacherEducationResponse.Error.Add(e.Message);
            getTeacherEducationResponse.Success = false;
            return getTeacherEducationResponse;
        }
    }
}