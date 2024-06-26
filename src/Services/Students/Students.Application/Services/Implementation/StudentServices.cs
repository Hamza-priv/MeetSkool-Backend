using AutoMapper;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.DTOS.Response.SubjectDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IEducationServices _educationServices;
    private readonly IStudentSubjectServices _studentSubjectServices;

    public StudentServices(IStudentRepository studentRepository, IMapper mapper, IEducationServices educationServices,
        IStudentSubjectServices studentSubjectServices)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _educationServices = educationServices;
        _studentSubjectServices = studentSubjectServices;
    }


    public async Task<ServiceResponse<AddStudentResponseDto>> AddStudent(AddStudentRequestDto studentDto)
    {
        var addStudentResponse = new ServiceResponse<AddStudentResponseDto>()
        {
            Data = new AddStudentResponseDto()
        };
        try
        {
            var student = _mapper.Map<Student>(studentDto);
            var result = await _studentRepository.AddAsync(student);
            if (result != null)
            {
                addStudentResponse.Data.StudentId = result.StudentId;
                addStudentResponse.Data.StudentName = result.StudentName;
                addStudentResponse.Messages.Add("Student added successfully");
                return addStudentResponse;
            }

            addStudentResponse.Error.Add("Student not added");
            addStudentResponse.Success = false;
            return addStudentResponse;
        }
        catch (Exception e)
        {
            addStudentResponse.Error.Add(e.Message);
            addStudentResponse.Success = false;
            return addStudentResponse;
        }
    }

    public async Task<ServiceResponse<UpdateStudentResponseDto>> UpdateStudent(UpdateStudentRequestDto updateStudentDto)
    {
        var updateStudentResponse = new ServiceResponse<UpdateStudentResponseDto>()
        {
            Data = new UpdateStudentResponseDto()
        };
        try
        {
            if (updateStudentDto.StudentId != null)
            {
                var dbStudent = await _studentRepository.GetByIdAsync(updateStudentDto.StudentId);
                if (dbStudent != null)
                {
                    var newStudent = _mapper.Map(dbStudent, updateStudentDto);
                    var updatedStudent = _mapper.Map<Student>(newStudent);
                    var result = await _studentRepository.UpdateAsync(updatedStudent);
                    if (result is not null)
                    {
                        updateStudentResponse.Data = _mapper.Map<UpdateStudentResponseDto>(updatedStudent);
                        updateStudentResponse.Messages.Add("Student updated successfully");
                        return updateStudentResponse;
                    }

                    updateStudentResponse.Error.Add("Student not updated");
                    updateStudentResponse.Success = false;
                    return updateStudentResponse;
                }
            }

            updateStudentResponse.Error.Add("Student Id can not be null");
            updateStudentResponse.Success = false;
            return updateStudentResponse;
        }
        catch (Exception e)
        {
            updateStudentResponse.Error.Add(e.Message);
            updateStudentResponse.Success = false;
            return updateStudentResponse;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteStudent(string id)
    {
        var deleteStudentResponse = new ServiceResponse<bool>();
        try
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(id);
            if (studentToDelete != null)
            {
                var result = await _studentRepository.DeleteAsync(studentToDelete);
                if (result)
                {
                    deleteStudentResponse.Data = true;
                    deleteStudentResponse.Messages.Add("Student deleted successfully");
                    return deleteStudentResponse;
                }

                deleteStudentResponse.Error.Add("Student not deleted");
                deleteStudentResponse.Success = false;
                deleteStudentResponse.Data = false;
                return deleteStudentResponse;
            }

            deleteStudentResponse.Error.Add("Student not found");
            deleteStudentResponse.Success = false;
            deleteStudentResponse.Data = false;
            return deleteStudentResponse;
        }
        catch (Exception e)
        {
            deleteStudentResponse.Error.Add(e.Message);
            deleteStudentResponse.Success = false;
            return deleteStudentResponse;
        }
    }

    public async Task<ServiceResponse<GetAllInfoOfStudentResponseDto>> GetAllInfoOfStudent(string studentId)
    {
        var getStudentResponse = new ServiceResponse<GetAllInfoOfStudentResponseDto>()
        {
            Data = new GetAllInfoOfStudentResponseDto()
        };
        try
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student != null)
            {
                /*
                getStudentResponse.Data = _mapper.Map<GetAllInfoOfStudentResponseDto>(student);
                */
                getStudentResponse.Messages.Add("Student found successfully");
                var studentEducation = await _educationServices.GetStudentEducation(studentId);
                if (studentEducation.Success)
                {
                    getStudentResponse.Data = _mapper.Map<GetAllInfoOfStudentResponseDto>(studentEducation.Data);
                    getStudentResponse.Messages.Add("StudentEducation found successfully");
                    var studentSubjects = await _studentSubjectServices.GetStudentSubject(studentId);
                    if (studentSubjects.Success)
                    {
                        var subjects = _mapper.Map<List<GetSubjectResponseDto>>(studentSubjects.Data);
                        getStudentResponse.Data.Subjects = subjects;
                        getStudentResponse.Data.StudentName = student.StudentName;
                        getStudentResponse.Data.Descriptions = student.Descriptions;
                        getStudentResponse.Data.TotalOrder = student.TotalOrder;
                        getStudentResponse.Data.StudentId = student.StudentId;
                        getStudentResponse.Messages.Add("StudentSubjects found successfully");
                        return getStudentResponse;
                    }

                    getStudentResponse.Error.Add("StudentSubjects not found");
                    getStudentResponse.Success = false;
                    return getStudentResponse;
                }

                getStudentResponse.Error.Add("StudentEducation not found");
                getStudentResponse.Success = false;
                return getStudentResponse;
            }

            getStudentResponse.Error.Add("Student not found");
            getStudentResponse.Success = false;
            return getStudentResponse;
        }
        catch (Exception e)
        {
            getStudentResponse.Error.Add(e.Message);
            getStudentResponse.Success = false;
            return getStudentResponse;
        }
    }

    public async Task<ServiceResponse<List<GetStudentListResponseDto>>> GetAllStudents(string? searchTerm)
    {
        var getStudentListResponse = new ServiceResponse<List<GetStudentListResponseDto>>();
        try
        {
            var students = await _studentRepository.SearchStudents(searchTerm);
            if (students.Count > 0)
            {
                /*
                var list = await Pagination<Student>.GetPaginatedList(students.AsQueryable(), page, pageSize);
                */
                getStudentListResponse.Data = _mapper.Map<List<GetStudentListResponseDto>>(students);
                getStudentListResponse.Messages.Add("Students found successfully");
                return getStudentListResponse;
            }

            getStudentListResponse.Error.Add("Students not found");
            getStudentListResponse.Success = false;
            return getStudentListResponse;
        }
        catch (Exception e)
        {
            getStudentListResponse.Error.Add(e.Message);
            getStudentListResponse.Success = false;
            return getStudentListResponse;
        }
    }
}