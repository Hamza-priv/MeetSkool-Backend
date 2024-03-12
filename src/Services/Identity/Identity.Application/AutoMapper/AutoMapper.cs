using AutoMapper;
using Identity.Application.ViewModels;
using Identity.Core.Entities;

namespace Identity.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // source ----> destination

        CreateMap<MeetSkoolUser, MeetSkoolIdentityUser>();
        CreateMap<MeetSkoolIdentityUser, UserCreationResponse>();
    }
}