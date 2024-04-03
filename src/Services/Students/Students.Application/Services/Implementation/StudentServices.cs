using AutoMapper;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentServices(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
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
                    if (result != null)
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
}