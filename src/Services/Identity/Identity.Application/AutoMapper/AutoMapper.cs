using AutoMapper;
using Identity.Application.ViewModels;
using Identity.Core.Entities;

namespace Identity.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // source ----> destination

        CreateMap<MeetSkoolUser, MeetSkoolIdentityUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.UserImage))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<MeetSkoolIdentityUser, UserCreationResponse>();
        CreateMap<MeetSkoolIdentityUser, UserUpdateResponse>();
        CreateMap<UpdateUser, MeetSkoolIdentityUser>();
        CreateMap<MeetSkoolIdentityUser, MeetSkoolUser>();
        CreateMap<MeetSkoolIdentityUser, UserInfo>();
        CreateMap<GeneratePasswordResetToken, ForgotPasswordResponse>();
    }
}