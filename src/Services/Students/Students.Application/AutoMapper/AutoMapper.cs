using AutoMapper;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Core.Entities;

namespace Students.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // source ----> destination

        //Request Mapping

        CreateMap<AddStudentRequestDto, Student>();
        CreateMap<UpdateStudentRequestDto, Student>();
        CreateMap<AddEducationRequestDto, Education>();
        CreateMap<UpdateEducationRequestDto, Education>();
        CreateMap<AddFriendRequestDto, Friend>();
        CreateMap<AddStudentSubjectRequestDto, StudentSubject>();
        CreateMap<AddStudentSubjectRequestDto, StudentSubject>();

        //Response Mapping
        
        
    }
}