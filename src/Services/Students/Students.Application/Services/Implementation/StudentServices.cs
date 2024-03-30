using Students.Application.DTOS.Response.StudentDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;

namespace Students.Application.Services.Implementation;

public class StudentServices : IStudentServices
{
    public async Task<ServiceResponse<AddStudentResponseDto>> AddStudent()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<UpdateStudentResponseDto>> UpdateStudent()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<bool>> DeleteStudent()
    {
        throw new NotImplementedException();
    }
}