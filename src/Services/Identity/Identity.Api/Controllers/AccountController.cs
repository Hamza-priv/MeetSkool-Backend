using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;
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
    [Route("createUser")]
    public async Task<ActionResult<ServiceResponse<UserCreationResponse>>> CreateUser([FromBody] MeetSkoolUser user)
    {
        try
        {
            var response = await _accountServices.CreateUser(user);

            if (response is not { Success: true, Data.Code: not null }) return BadRequest(response);

            var check = user.Email != null && await _emailServices.SendConfirmAccount(response.Data.UserId,
                response.Data.Code, user.FullName, user.Email);

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

    [HttpGet]
    [Route("resendEmail")]
    public async Task<ActionResult<bool>> ResendAccountConfirmationEmail(Guid userId, string code, string email)
    {
        try
        {
            var check = await _emailServices.ResendConfirmAccount(userId, code, email, email);
            if (check)
            {
                return Ok(check);
            }

            return BadRequest(check);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("confirmEmail")]
    public async Task<ActionResult<ServiceResponse<ConfirmEmailResponse>>> ConfirmEmail(string userId, string code)
    {
        try
        {
            var response = await _accountServices.ConfirmEmail(userId, code);
            if (!response.Success) return BadRequest(response);
            var sendEmail = response.Data is { UserName: not null, Email: not null } &&
                            await _emailServices.EmailConfirmedNotification(userId, response.Data.UserName,
                                response.Data.Email);
            if (sendEmail)
            {
                response.Messages.Add("Email Sent");
                return Ok(response);
            }

            response.Error.Add("Email not sent");
            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    [Route("updateUser")]
    public async Task<ActionResult<ServiceResponse<UserUpdateResponse>>> UpdateUser([FromBody] UpdateUser user)
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
    [Route("userSign")]
    public async Task<ActionResult<ServiceResponse<UserSignInResponse>>> UserSign([FromBody] UserSignInModel user)
    {
        try
        {
            var response = await _accountServices.PasswordSignInAsync(user);
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
    [Route("changePassword")]
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

    [HttpPost]
    [Route("forgotPassword")]
    public async Task<ActionResult<ServiceResponse<ResetPasswordResponse>>> ForgotPassword(string email)
    {
        try
        {
            var response = await _accountServices.GeneratePasswordResetToken(email);
            if (!response.Success) return BadRequest(response);
            if (response is { Success: true, Data: { Token: not null, FullName: not null } })
            {
                var emailSent = await _emailServices.SendForgetPassword(response.Data.UserId, response.Data.Token,
                    response.Data.FullName, email);
                if (emailSent)
                {
                    response.Messages.Add("Email sent");
                    return Ok(response);
                }
            }

            response.Error.Add("Email not sent");
            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("resetPassword")]
    public async Task<ActionResult<ServiceResponse<ResetPasswordResponse>>> ResetPassword(string userId, string code,
        string newPassword)
    {
        try
        {
            var response = await _accountServices.ResetPassword(userId, code, newPassword);
            if (!response.Success) return BadRequest(response);
            var emailSent = response.Data is { Email: not null, FullName: not null } &&
                            await _emailServices.PasswordChangedNotification(userId, code, newPassword,
                                response.Data.FullName, response.Data.Email);
            if (emailSent)
            {
                response.Messages.Add("Email sent");
                return Ok(response);
            }

            response.Error.Add("Email not sent");
            return BadRequest(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete]
    [Route("deleteUser")]
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
    [Route("getTeacherList")]
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
    [Route("getStudentsList")]
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
    [Route("teachersCount")]
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
    [Route("studentsCount")]
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
    [Route("findUser")]
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