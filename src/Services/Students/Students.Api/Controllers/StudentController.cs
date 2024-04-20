using Microsoft.AspNetCore.Mvc;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Application.DTOS.Response.EducationDto;
using Students.Application.DTOS.Response.FriendDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.DTOS.Response.StudentSubjectDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;

namespace Students.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IEducationServices _educationServices;
    private readonly IStudentServices _studentServices;
    private readonly IStudentSubjectServices _studentSubjectServices;
    private readonly IFriendServices _friendServices;

    public StudentController(IEducationServices educationServices, IStudentServices studentServices,
        IStudentSubjectServices studentSubjectServices, IFriendServices friendServices)
    {
        _educationServices = educationServices;
        _studentServices = studentServices;
        _studentSubjectServices = studentSubjectServices;
        _friendServices = friendServices;
    }

    // Student Controller

    [Route("createStudent")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddStudentResponseDto>>> CreateStudent(
        [FromBody] AddStudentRequestDto addStudentRequestDto)
    {
        try
        {
            var result = await _studentServices.AddStudent(addStudentRequestDto);
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

    [Route("updateStudent")]
    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<UpdateStudentResponseDto>>> UpdateStudent(
        [FromBody] UpdateStudentRequestDto updateStudentRequestDto)
    {
        try
        {
            // tracking issue
            var result = await _studentServices.UpdateStudent(updateStudentRequestDto);
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

    [Route("deleteStudent")]
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteStudent(string studentId)
    {
        try
        {
            var result = await _studentServices.DeleteStudent(studentId);
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

    [Route("getStudentInfo")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetAllInfoOfStudentResponseDto>>> GetStudentInfo(string studentId)
    {
        try
        {
            var result = await _studentServices.GetAllInfoOfStudent(studentId);
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

    // Get All student method need to be implemented 


    // Education Controller

    [Route("createStudentEducation")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddEducationResponseDto>>> CreateStudentEducation(
        [FromBody] AddEducationRequestDto educationRequestDto)
    {
        try
        {
            var result = await _educationServices.AddEducation(educationRequestDto);
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

    [Route("updateStudentEducation")]
    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<UpdateEducationResponseDto>>> UpdateStudentEducation(
        [FromBody] UpdateEducationRequestDto updateEducationRequestDto)
    {
        try
        {
            var result = await _educationServices.UpdateEducation(updateEducationRequestDto);
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

    [Route("getStudentEducation")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetStudentEducationResponseDto>>> GetStudentEducation(
        string studentId)
    {
        try
        {
            var result = await _educationServices.GetStudentEducation(studentId);
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

    // StudentSubject Controller

    [Route("addStudentSubject")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddStudentSubjectResponseDto>>> AddStudentSubject(
        [FromBody] AddStudentSubjectRequestDto addStudentSubjectRequestDto)
    {
        try
        {
            var result = await _studentSubjectServices.AddStudentSubject(addStudentSubjectRequestDto);
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

    [Route("getStudentSubject")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetStudentSubjectResponseDto>>> GetStudentSubject(string studentId)
    {
        try
        {
            var result = await _studentSubjectServices.GetStudentSubject(studentId);
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

    // Friends Controller

    [Route("addStudentFriend")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddFriendResponseDto>>> AddStudentFriend(
        AddFriendRequestDto addFriendRequestDto)
    {
        try
        {
            var result = await _friendServices.AddFriend(addFriendRequestDto);
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

    [Route("getStudentFriends")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetStudentFriendResponseDto>>>> GetStudentFriends(
        string studentId)
    {
        try
        {
            var result = await _friendServices.GetFriends(studentId);
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

    [Route("deleteStudentFriends")]
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteStudentFriends(string friendId, string studentId)
    {
        try
        {
            var result = await _friendServices.DeleteFriend(friendId, studentId);
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