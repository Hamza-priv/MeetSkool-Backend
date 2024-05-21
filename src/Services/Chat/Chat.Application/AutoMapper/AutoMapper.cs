using AutoMapper;
using Chat.Application.Dtos.Request.Groups;
using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Groups;
using Chat.Application.Dtos.Response.Messages;
using Chat.Core.Models;
using Contracts;

namespace Chat.Application.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Source ---> Destination

        // Response Mapping

        CreateMap<Messages, GetUserConversationResponseDto>();
        CreateMap<Messages, GetUserGroupMessagesResponseDto>();
        CreateMap<Conversations, GetUserConversationResponseDto>();
        CreateMap<Groups, GetUserGroupResponseDto>();

        // Request Mapping

        CreateMap<AddMemberInGroupRequestDto, AddMemberInGroupEvent>();
        CreateMap<RemoveMemberFromGroupRequestDto, RemoveMemberFromGroupEvent>();
        CreateMap<AddGroupMessageRequestDto, Messages>();
        CreateMap<AddConversationMessageRequestDto, Messages>();
    }
}