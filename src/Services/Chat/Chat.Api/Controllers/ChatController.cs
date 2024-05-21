using Chat.Application.Dtos.Request.Messages;
using Chat.Application.Dtos.Response.Groups;
using Chat.Application.Dtos.Response.Messages;
using Chat.Application.ServiceResponse;
using Chat.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IGroupServices _groupServices;
    private readonly IMessageServices _messageServices;
    private readonly IConversationServices _conversationServices;

    public ChatController(IGroupServices groupServices, IMessageServices messageServices,
        IConversationServices conversationServices)
    {
        _groupServices = groupServices;
        _messageServices = messageServices;
        _conversationServices = conversationServices;
    }

    [HttpGet]
    [Route("getUserGroups")]
    public async Task<ActionResult<ServiceResponse<List<GetUserGroupResponseDto>>>> GetUserGroups(string userId)
    {
        try
        {
            var result = await _groupServices.GetUserGroups(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("getGroupMessages")]
    public async Task<ActionResult<ServiceResponse<List<GetUserGroupMessagesResponseDto>>>> GetGroupMessages(
        string groupId)
    {
        try
        {
            var result = await _messageServices.GetGroupMessages(groupId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("getUserConversations")]
    public async Task<ActionResult<ServiceResponse<List<GetUserConversationResponseDto>>>>
        GetUserConversations(string userId)
    {
        try
        {
            var result = await _conversationServices.GetUserConversationList(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("getUserConversationMessages")]
    public async Task<ActionResult<ServiceResponse<List<GetUserConversationResponseDto>>>>
        GetUserConversationMessages(GetUserConversationRequestDto userConversationRequestDto)
    {
        try
        {
            var result = await _messageServices.GetUserConversation(userConversationRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}