using AutoMapper;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Request.StudentDto;
using Students.Core.Entities;

namespace Students.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        //Request Mapping
        
        // source ----> destination
        CreateMap<AddStudentRequestDto, Student>();
        CreateMap<UpdateStudentRequestDto, Student>();
        CreateMap<AddEducationRequestDto, Education>();
        CreateMap<UpdateEducationRequestDto, Education>();
        CreateMap<AddFriendRequestDto, Friend>();
        
        //Response Mapping
        
        
    }
}