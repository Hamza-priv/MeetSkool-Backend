using AutoMapper;
using Teachers.Application.DTOS.Request.TeacherDto;
using Teachers.Application.DTOS.Response.TeacherDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;

namespace Teachers.Application.Services.Implementation;

public class TeacherServices : ITeacherServices
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;
    private readonly IEducationServices _educationServices;
    private readonly ITeacherSubjectServices _teacherSubjectServices;

    public TeacherServices(ITeacherRepository teacherRepository, IMapper mapper, IEducationServices educationServices,
        ITeacherSubjectServices teacherSubjectServices)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
        _educationServices = educationServices;
        _teacherSubjectServices = teacherSubjectServices;
    }

    public async Task<ServiceResponse<AddTeacherResponseDto>> AddStudent(AddTeacherRequestDto teacherDto)
    {
        var addTeacherResponse = new ServiceResponse<AddTeacherResponseDto>()
        {
            Data = new AddTeacherResponseDto()
        };
        try
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            var result = await _teacherRepository.AddAsync(teacher);
            if (result != null)
            {
                addTeacherResponse.Data.TeacherId = result.TeacherId;
                addTeacherResponse.Data.TeacherName = result.TeacherName;
                addTeacherResponse.Messages.Add("Teacher added successfully");
                return addTeacherResponse;
            }

            addTeacherResponse.Error.Add("Teacher not added");
            addTeacherResponse.Success = false;
            return addTeacherResponse;
        }
        catch (Exception e)
        {
            addTeacherResponse.Error.Add(e.Message);
            addTeacherResponse.Success = false;
            return addTeacherResponse;
        }
    }

    public async Task<ServiceResponse<UpdateTeacherResponseDto>> UpdateStudent(UpdateTeacherRequestDto updateTeacherDto)
    {
        var updateTeacherResponse = new ServiceResponse<UpdateTeacherResponseDto>()
        {
            Data = new UpdateTeacherResponseDto()
        };
        try
        {
            if (updateTeacherDto.TeacherId != null)
            {
                var dbTeacher = await _teacherRepository.GetByIdAsync(updateTeacherDto.TeacherId);
                if (dbTeacher != null)
                {
                    var newTeacher = _mapper.Map(dbTeacher, updateTeacherDto);
                    var updatedTeacher = _mapper.Map<Teacher>(newTeacher);
                    var result = await _teacherRepository.UpdateAsync(updatedTeacher);
                    if (result is not null)
                    {
                        updateTeacherResponse.Data = _mapper.Map<UpdateTeacherResponseDto>(updatedTeacher);
                        updateTeacherResponse.Messages.Add("Teacher updated successfully");
                        return updateTeacherResponse;
                    }

                    updateTeacherResponse.Error.Add("Teacher not updated");
                    updateTeacherResponse.Success = false;
                    return updateTeacherResponse;
                }
            }

            updateTeacherResponse.Error.Add("Teacher Id can not be null");
            updateTeacherResponse.Success = false;
            return updateTeacherResponse;
        }
        catch (Exception e)
        {
            updateTeacherResponse.Error.Add(e.Message);
            updateTeacherResponse.Success = false;
            return updateTeacherResponse;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteStudent(string id)
    {
        var deleteTeacherResponse = new ServiceResponse<bool>();
        try
        {
            var teacherToDelete = await _teacherRepository.GetByIdAsync(id);
            if (teacherToDelete != null)
            {
                var result = await _teacherRepository.DeleteAsync(teacherToDelete);
                if (result)
                {
                    deleteTeacherResponse.Data = true;
                    deleteTeacherResponse.Messages.Add("Teacher deleted successfully");
                    return deleteTeacherResponse;
                }

                deleteTeacherResponse.Error.Add("Teacher not deleted");
                deleteTeacherResponse.Success = false;
                deleteTeacherResponse.Data = false;
                return deleteTeacherResponse;
            }

            deleteTeacherResponse.Error.Add("Teacher not found");
            deleteTeacherResponse.Success = false;
            deleteTeacherResponse.Data = false;
            return deleteTeacherResponse;
        }
        catch (Exception e)
        {
            deleteTeacherResponse.Error.Add(e.Message);
            deleteTeacherResponse.Success = false;
            return deleteTeacherResponse;
        }
    }

    public async Task<ServiceResponse<GetAllInfoOfTeacherResponseDto>> GetAllInfoOfStudent(string teacherId)
    {
        var getTeacherResponse = new ServiceResponse<GetAllInfoOfTeacherResponseDto>()
        {
            Data = new GetAllInfoOfTeacherResponseDto()
        };
        try
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            if (teacher != null)
            {
                getTeacherResponse.Data = _mapper.Map<GetAllInfoOfTeacherResponseDto>(teacher);
                getTeacherResponse.Messages.Add("Teacher found successfully");
                var studentEducation = await _educationServices.GetTeacherEducation(teacherId);
                if (studentEducation.Success)
                {
                    getTeacherResponse.Data = _mapper.Map<GetAllInfoOfTeacherResponseDto>(studentEducation);
                    getTeacherResponse.Messages.Add("TeacherEducation found successfully");
                    var studentSubjects = await _teacherSubjectServices.GetTeacherSubject(teacherId);
                    if (studentSubjects.Success)
                    {
                        getTeacherResponse.Data = _mapper.Map<GetAllInfoOfTeacherResponseDto>(studentSubjects);
                        getTeacherResponse.Messages.Add("TeacherSubjects found successfully");
                        return getTeacherResponse;
                    }

                    getTeacherResponse.Error.Add("TeacherSubjects not found");
                    getTeacherResponse.Success = false;
                    return getTeacherResponse;
                }

                getTeacherResponse.Error.Add("TeacherEducation not found");
                getTeacherResponse.Success = false;
                return getTeacherResponse;
            }

            getTeacherResponse.Error.Add("Teacher not found");
            getTeacherResponse.Success = false;
            return getTeacherResponse;
        }
        catch (Exception e)
        {
            getTeacherResponse.Error.Add(e.Message);
            getTeacherResponse.Success = false;
            return getTeacherResponse;
        }
    }

    public async Task<ServiceResponse<GetTeacherListResponseDto>> GetAllStudents(string? searchTerm, int page,
        int pageSize)
    {
        var getTeacherListResponse = new ServiceResponse<GetTeacherListResponseDto>()
        {
            Data = new GetTeacherListResponseDto()
        };
        try
        {
            var teachers = await _teacherRepository.SearchTeacher(searchTerm);
            if (teachers.Count > 0)
            {
                /*
                var list = await Pagination<Student>.GetPaginatedList(students.AsQueryable(), page, pageSize);
                */
                getTeacherListResponse.Data = _mapper.Map<GetTeacherListResponseDto>(teachers);
                getTeacherListResponse.Messages.Add("Teachers found successfully");
                return getTeacherListResponse;
            }

            getTeacherListResponse.Error.Add("Teachers not found");
            getTeacherListResponse.Success = false;
            return getTeacherListResponse;
        }
        catch (Exception e)
        {
            getTeacherListResponse.Error.Add(e.Message);
            getTeacherListResponse.Success = false;
            return getTeacherListResponse;
        }
    }
}