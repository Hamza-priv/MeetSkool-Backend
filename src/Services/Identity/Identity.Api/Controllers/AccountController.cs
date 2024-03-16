using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/Account")]
public class AccountController : ControllerBase
{
    private readonly IAccountServices _accountServices;
    private readonly IEmailServices _emailServices;

    public AccountController(IAccountServices accountServices, IEmailServices emailServices)
    {
        _accountServices = accountServices;
        _emailServices = emailServices;
    }

    [HttpPost]
    [Route("/createUser")]
    public async Task<ActionResult<ServiceResponse<UserCreationResponse>>> CreateUser([FromBody] MeetSkoolUser user)
    {
        try
        {
            var response = await _accountServices.CreateUser(user);
            
            if (response is not { Success: true, Data.Code: not null }) return BadRequest(response);
            
            var check = user.Email != null && await _emailServices.SendConfirmAccount(response.Data.UserId, response.Data.Code, user.FullName, user.Email);
            
            if (check)
            {
                response.Messages.Add("Email sent");
                return Ok(response);
            }
            
            response.Error.Add("Email not sent");
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    [Route("/updateUser")]
    public async Task<ActionResult<ServiceResponse<UserCreationResponse>>> UpdateUser([FromBody] MeetSkoolUser user)
    {
        try
        {
            var response = await _accountServices.UpdateUser(user);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    [Route("/forgetPassword")]
    public async Task<ActionResult<ServiceResponse<UserCreationResponse>>> ChangePassword(ChangePassword changePassword)
    {
        try
        {
            var response = await _accountServices.ChangePassword(changePassword);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete]
    [Route("/deleteUser")]
    public async Task<ActionResult<ServiceResponse<IdentityResult>>> DeleteUser(string email)
    {
        try
        {
            var response = await _accountServices.DeleteUser(email);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("/getTeacherList")]
    public async Task<ActionResult<ServiceResponse<List<MeetSkoolUser>>>> GetTeacherList()
    {
        try
        {
            var response = await _accountServices.GetTeachersList();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("/getStudentsList")]
    public async Task<ActionResult<ServiceResponse<List<MeetSkoolUser>>>> GetStudentsList()
    {
        try
        {
            var response = await _accountServices.GetStudentsList();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("/teachersCount")]
    public async Task<ActionResult<ServiceResponse<int>>> GetTeachersCount()
    {
        try
        {
            var response = await _accountServices.GetTeachersCount();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("/studentsCount")]
    public async Task<ActionResult<ServiceResponse<int>>> GetStudentsCount()
    {
        try
        {
            var response = await _accountServices.GetStudentsCount();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("/findUser")]
    public async Task<ActionResult<ServiceResponse<MeetSkoolUser>>> FindByEmail(string email)
    {
        try
        {
            var response = await _accountServices.FindByEmail(email);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}