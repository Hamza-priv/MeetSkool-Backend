using AutoMapper;
using Teachers.Application.DTOS.Request.EducationDto;
using Teachers.Application.DTOS.Request.TeacherDto;
using Teachers.Application.DTOS.Request.TeacherSubjectDto;
using Teachers.Application.DTOS.Response.EducationDto;
using Teachers.Application.DTOS.Response.SubjectDto;
using Teachers.Application.DTOS.Response.TeacherDto;
using Teachers.Application.DTOS.Response.TeacherSubjectDto;
using Teachers.Core.Entities;

namespace Teachers.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // source ----> destination

        //Request Mapping

        CreateMap<AddTeacherRequestDto, Teacher>();
        CreateMap<UpdateTeacherRequestDto, Teacher>();
        CreateMap<AddEducationRequestDto, Education>();
        CreateMap<UpdateEducationRequestDto, Education>();
        CreateMap<AddTeacherSubjectRequestDto, TeacherSubject>();

        //Response Mapping

        CreateMap<Teacher, UpdateTeacherRequestDto>();
        CreateMap<Teacher, GetAllInfoOfTeacherResponseDto>();
        CreateMap<Education, GetAllInfoOfTeacherResponseDto>();
        CreateMap<Subject, GetAllInfoOfTeacherResponseDto>();
        CreateMap<Education, AddEducationResponseDto>();
        CreateMap<Education, UpdateEducationResponseDto>();
        CreateMap<Education, UpdateEducationRequestDto>();
        CreateMap<Education, GetTeacherEducationResponseDto>();
        CreateMap<Subject, GetSubjectResponseDto>();
        CreateMap<TeacherSubject, AddTeacherSubjectResponseDto>();
        CreateMap<TeacherSubject, GetTeacherSubjectResponseDto>();
        CreateMap<Teacher, GetTeacherListResponseDto>();
    }
}