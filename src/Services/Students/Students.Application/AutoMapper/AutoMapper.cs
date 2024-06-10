using AutoMapper;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Request.OrderDto;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Application.DTOS.Response.EducationDto;
using Students.Application.DTOS.Response.FriendDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.DTOS.Response.StudentSubjectDto;
using Students.Application.DTOS.Response.SubjectDto;
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
        CreateMap<AddOrderRequestDto, Order>();

        //Response Mapping

        CreateMap<Student, UpdateStudentRequestDto>();
        CreateMap<Student, GetAllInfoOfStudentResponseDto>();
        CreateMap<Education, GetAllInfoOfStudentResponseDto>();
        CreateMap<Subject, GetAllInfoOfStudentResponseDto>();
        CreateMap<Education, AddEducationResponseDto>();
        CreateMap<Education, UpdateEducationResponseDto>();
        CreateMap<Education, UpdateEducationRequestDto>();
        CreateMap<Education, GetStudentEducationResponseDto>();
        CreateMap<Subject, GetSubjectResponseDto>();
        CreateMap<StudentSubject, AddStudentSubjectResponseDto>();
        CreateMap<StudentSubject, GetStudentSubjectResponseDto>();
        CreateMap<Friend, AddFriendResponseDto>();
        CreateMap<Friend, GetStudentFriendResponseDto>();
        CreateMap<Subject, GetSubjectListResponseDto>();
        CreateMap<Student, GetStudentListResponseDto>();
    }
}