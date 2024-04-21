using AutoMapper;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Response.EducationDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

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
            if (updateEducationRequestDto.StudentId != null)
            {
                var dbEducation = await _educationRepository.GetStudentEducation(updateEducationRequestDto.StudentId);
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

    public async Task<ServiceResponse<GetStudentEducationResponseDto>> GetStudentEducation(string studentId)
    {
        var getStudentEducationResponse = new ServiceResponse<GetStudentEducationResponseDto>()
        {
            Data = new GetStudentEducationResponseDto()
        };
        try
        {
            var studentEducation = await _educationRepository.GetStudentEducation(studentId);
            if (studentEducation is not null)
            {
                getStudentEducationResponse.Data = _mapper.Map<GetStudentEducationResponseDto>(studentEducation);
                getStudentEducationResponse.Messages.Add("StudentEducationFound");
                return getStudentEducationResponse;
            }

            getStudentEducationResponse.Error.Add("StudentEducationNotFound");
            getStudentEducationResponse.Success = false;
            return getStudentEducationResponse;
        }
        catch (Exception e)
        {
            getStudentEducationResponse.Error.Add(e.Message);
            getStudentEducationResponse.Success = false;
            return getStudentEducationResponse;
        }
    }
}