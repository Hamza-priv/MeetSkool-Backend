using AutoMapper;
using Teachers.Application.DTOS.Request.TeacherSubjectDto;
using Teachers.Application.DTOS.Response.TeacherSubjectDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;

namespace Teachers.Application.Services.Implementation;

public class TeacherSubjectServices : ITeacherSubjectServices
{
    private readonly ISubjectServices _subjectServices;
    private readonly ITeacherSubjectRepository _teacherSubjectsRepository;
    private readonly IMapper _mapper;

    public TeacherSubjectServices(ISubjectServices subjectServices, IMapper mapper,
        ITeacherSubjectRepository teacherSubjectsRepository)
    {
        _subjectServices = subjectServices;
        _mapper = mapper;
        _teacherSubjectsRepository = teacherSubjectsRepository;
    }

    public async Task<ServiceResponse<AddTeacherSubjectResponseDto>> AddTeacherSubject(
        AddTeacherSubjectRequestDto addTeacherSubjectRequestDto)
    {
        var addTeacherSubjectResponse = new ServiceResponse<AddTeacherSubjectResponseDto>()
        {
            Data = new AddTeacherSubjectResponseDto()
        };
        try
        {
            if (addTeacherSubjectRequestDto.SubjectId != Guid.Empty)
            {
                var subject = await _subjectServices.GetSubject(addTeacherSubjectRequestDto.SubjectId);
                if (subject is not null)
                {
                    var teacherSubject = _mapper.Map<TeacherSubject>(addTeacherSubjectRequestDto);
                    teacherSubject.SubjectName = subject.SubjectName;
                    var result = await _teacherSubjectsRepository.AddAsync(teacherSubject);
                    if (result is not null)
                    {
                        addTeacherSubjectResponse.Data = _mapper.Map<AddTeacherSubjectResponseDto>(result);
                        addTeacherSubjectResponse.Messages.Add("Teacher subject added successfully");
                        return addTeacherSubjectResponse;
                    }

                    addTeacherSubjectResponse.Error.Add("Teacher subject not added");
                    addTeacherSubjectResponse.Success = false;
                    return addTeacherSubjectResponse;
                }

                addTeacherSubjectResponse.Error.Add("Subject not found");
                addTeacherSubjectResponse.Success = false;
                return addTeacherSubjectResponse;
            }

            addTeacherSubjectResponse.Error.Add("Subject id is required");
            addTeacherSubjectResponse.Success = false;
            return addTeacherSubjectResponse;
        }
        catch (Exception e)
        {
            addTeacherSubjectResponse.Error.Add(e.Message);
            addTeacherSubjectResponse.Success = false;
            return addTeacherSubjectResponse;
        }
    }

    public async Task<ServiceResponse<List<GetTeacherSubjectResponseDto>>> GetTeacherSubject(string teacherId)
    {
        var getTeacherSubjectResponse = new ServiceResponse<List<GetTeacherSubjectResponseDto>>();

        try
        {
            if (!string.IsNullOrWhiteSpace(teacherId))
            {
                var result = await _teacherSubjectsRepository.GetTeacherSubjects(teacherId);
                if (result is not null)
                {
                    getTeacherSubjectResponse.Data = _mapper.Map<List<GetTeacherSubjectResponseDto>>(result);
                    getTeacherSubjectResponse.Messages.Add("Teacher subject found");
                    return getTeacherSubjectResponse;
                }

                getTeacherSubjectResponse.Error.Add("Teacher subject not found");
                getTeacherSubjectResponse.Success = false;
                return getTeacherSubjectResponse;
            }

            getTeacherSubjectResponse.Error.Add("Teacher Id can not be null");
            getTeacherSubjectResponse.Success = false;
            return getTeacherSubjectResponse;
        }
        catch (Exception e)
        {
            getTeacherSubjectResponse.Error.Add(e.Message);
            getTeacherSubjectResponse.Success = false;
            return getTeacherSubjectResponse;
        }
    }
}