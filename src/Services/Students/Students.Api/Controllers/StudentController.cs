using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Students.Application.DTOS.Request.EducationDto;
using Students.Application.DTOS.Request.FriendDto;
using Students.Application.DTOS.Request.OrderDto;
using Students.Application.DTOS.Request.StudentDto;
using Students.Application.DTOS.Request.StudentSubjectDto;
using Students.Application.DTOS.Response.EducationDto;
using Students.Application.DTOS.Response.FriendDto;
using Students.Application.DTOS.Response.OrderDto;
using Students.Application.DTOS.Response.StudentDto;
using Students.Application.DTOS.Response.StudentSubjectDto;
using Students.Application.DTOS.Response.SubjectDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;

namespace Students.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IEducationServices _educationServices;
    private readonly IStudentServices _studentServices;
    private readonly IStudentSubjectServices _studentSubjectServices;
    private readonly IFriendServices _friendServices;
    private readonly ISubjectServices _subjectServices;
    private readonly IOrderServices _orderServices;

    public StudentController(IEducationServices educationServices, IStudentServices studentServices,
        IStudentSubjectServices studentSubjectServices, IFriendServices friendServices,
        ISubjectServices subjectServices, IOrderServices orderServices)
    {
        _educationServices = educationServices;
        _studentServices = studentServices;
        _studentSubjectServices = studentSubjectServices;
        _friendServices = friendServices;
        _subjectServices = subjectServices;
        _orderServices = orderServices;
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

    /*
    [Authorize(Roles = "Student")]
    */
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

    [Authorize(Roles = "Student,Admin")]
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

    /*
    [Authorize(Roles = "Student,Teacher")]
    */
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

    /*
    [Authorize(Roles = "Student,Admin")]
    */
    [Route("getAllStudents")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetStudentListResponseDto>>>> GetStudentList(string? searchTerm)
    {
        try
        {
            var result = await _studentServices.GetAllStudents(searchTerm);
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

    [Authorize(Roles = "Student")]
    [Route("updateStudentEducation")]
    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<UpdateEducationResponseDto>>> UpdateStudentEducation(
        [FromBody] UpdateEducationRequestDto updateEducationRequestDto)
    {
        try
        {
            // need fixing
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

    [Authorize(Roles = "Student")]
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

    [Authorize(Roles = "Student")]
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

    [Route("getSearchedSubjects")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetSubjectListResponseDto>>>> GetSearchedSubject(string? searchTerm)
    {
        try
        {
            var result = await _subjectServices.GetSearchedSubjects(searchTerm);
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

    [Authorize(Roles = "Student")]
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

    [Authorize(Roles = "Student")]
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

    [Authorize(Roles = "Student")]
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

    // Order Controller

    [Authorize(Roles = "Student")]
    [Route("getStudentOrders")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetOrdersResponseDto>>> GetOrders(string orderById)
    {
        try
        {
            var result = await _orderServices.GetOrders(orderById);
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