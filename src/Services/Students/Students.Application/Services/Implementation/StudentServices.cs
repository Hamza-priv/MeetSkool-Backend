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
        /*try
        {
            var student = _mapper.Map<Student>(studentDto);
            var result = await _studentRepository.AddAsync(student);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }*/
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<UpdateStudentResponseDto>> UpdateStudent(UpdateStudentRequestDto updateStudentDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<bool>> DeleteStudent(string id)
    {
        throw new NotImplementedException();
    }
}