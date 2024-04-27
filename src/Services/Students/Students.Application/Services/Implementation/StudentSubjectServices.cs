using AutoMapper;
using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Application.DTOS.Response.StudentSubjectDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class StudentSubjectServices : IStudentSubjectServices
{
    private readonly ISubjectServices _subjectServices;
    private readonly IStudentSubjectsRepository _studentSubjectsRepository;
    private readonly IMapper _mapper;

    public StudentSubjectServices(ISubjectServices subjectServices,
        IStudentSubjectsRepository studentSubjectsRepository, IMapper mapper)
    {
        _subjectServices = subjectServices;
        _studentSubjectsRepository = studentSubjectsRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AddStudentSubjectResponseDto>> AddStudentSubject(
        AddStudentSubjectRequestDto addStudentSubjectRequestDto)
    {
        var addStudentSubjectResponse = new ServiceResponse<AddStudentSubjectResponseDto>()
        {
            Data = new AddStudentSubjectResponseDto()
        };
        try
        {
            if (addStudentSubjectRequestDto.SubjectId != Guid.Empty)
            {
                var subject = await _subjectServices.GetSubject(addStudentSubjectRequestDto.SubjectId);
                if (subject is not null)
                {
                    var studentSubject = _mapper.Map<StudentSubject>(addStudentSubjectRequestDto);
                    studentSubject.SubjectName = subject.SubjectName;
                    var result = await _studentSubjectsRepository.AddAsync(studentSubject);
                    if (result is not null)
                    {
                        addStudentSubjectResponse.Data = _mapper.Map<AddStudentSubjectResponseDto>(result);
                        addStudentSubjectResponse.Messages.Add("Student subject added successfully");
                        return addStudentSubjectResponse;
                    }

                    addStudentSubjectResponse.Error.Add("Student subject not added");
                    addStudentSubjectResponse.Success = false;
                    return addStudentSubjectResponse;
                }

                addStudentSubjectResponse.Error.Add("Subject not found");
                addStudentSubjectResponse.Success = false;
                return addStudentSubjectResponse;
            }

            addStudentSubjectResponse.Error.Add("Subject id is required");
            addStudentSubjectResponse.Success = false;
            return addStudentSubjectResponse;
        }
        catch (Exception e)
        {
            addStudentSubjectResponse.Error.Add(e.Message);
            addStudentSubjectResponse.Success = false;
            return addStudentSubjectResponse;
        }
    }

    public async Task<ServiceResponse<List<GetStudentSubjectResponseDto>>> GetStudentSubject(
        string studentId)
    {
        var getStudentSubjectResponse = new ServiceResponse<List<GetStudentSubjectResponseDto>>();

        try
        {
            if (!string.IsNullOrWhiteSpace(studentId))
            {
                var result = await _studentSubjectsRepository.GetStudentSubjects(studentId);
                if (result is not null)
                {
                    getStudentSubjectResponse.Data = _mapper.Map<List<GetStudentSubjectResponseDto>>(result);
                    getStudentSubjectResponse.Messages.Add("Student subject found");
                    return getStudentSubjectResponse;
                }

                getStudentSubjectResponse.Error.Add("Student subject not found");
                getStudentSubjectResponse.Success = false;
                return getStudentSubjectResponse;
            }

            getStudentSubjectResponse.Error.Add("Student Id can not be null");
            getStudentSubjectResponse.Success = false;
            return getStudentSubjectResponse;
        }
        catch (Exception e)
        {
            getStudentSubjectResponse.Error.Add(e.Message);
            getStudentSubjectResponse.Success = false;
            return getStudentSubjectResponse;
        }
    }
}