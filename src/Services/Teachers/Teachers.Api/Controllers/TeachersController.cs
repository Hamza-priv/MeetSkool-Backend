using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Teachers.Application.DTOS.Request.CommentDto;
using Teachers.Application.DTOS.Request.EducationDto;
using Teachers.Application.DTOS.Request.TeacherDto;
using Teachers.Application.DTOS.Request.TeacherSubjectDto;
using Teachers.Application.DTOS.Response.CommentDto;
using Teachers.Application.DTOS.Response.EducationDto;
using Teachers.Application.DTOS.Response.SubjectDto;
using Teachers.Application.DTOS.Response.TeacherDto;
using Teachers.Application.DTOS.Response.TeacherSubjectDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;

namespace Teachers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly IEducationServices _educationServices;
    private readonly ITeacherServices _teacherServices;
    private readonly ITeacherSubjectServices _teacherSubjectServices;
    private readonly ICommentServices _commentServices;
    private readonly ISubjectServices _subjectServices;

    public TeachersController(IEducationServices educationServices, ITeacherServices teacherServices,
        ITeacherSubjectServices teacherSubjectServices, ICommentServices commentServices,
        ISubjectServices subjectServices)
    {
        _educationServices = educationServices;
        _teacherServices = teacherServices;
        _teacherSubjectServices = teacherSubjectServices;
        _commentServices = commentServices;
        _subjectServices = subjectServices;
    }

    // Teachers Controller 
    [Route("createTeacher")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddTeacherResponseDto>>> CreateTeacher(
        [FromBody] AddTeacherRequestDto addTeacherRequestDto)
    {
        try
        {
            var result = await _teacherServices.AddTeacher(addTeacherRequestDto);
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

    [Route("updateTeacher")]
    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<UpdateTeacherResponseDto>>> UpdateStudent(
        [FromBody] UpdateTeacherRequestDto updateTeacherRequestDto)
    {
        try
        {
            // tracking issue
            var result = await _teacherServices.UpdateTeacher(updateTeacherRequestDto);
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

    [Route("deleteTeacher")]
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteTeacher(string teacherId)
    {
        try
        {
            var result = await _teacherServices.DeleteTeacher(teacherId);
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

    [Route("getTeacherInfo")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetAllInfoOfTeacherResponseDto>>> GetTeacherInfo(string teacherId)
    {
        try
        {
            var result = await _teacherServices.GetAllInfoOfTeacher(teacherId);
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

    [Route("getAllTeachers")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetTeacherListResponseDto>>>> GetTeacherList(string? searchTerm,
        int page, int pageSize)
    {
        try
        {
            var result = await _teacherServices.GetAllTeachers(searchTerm, page, pageSize);
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

    [Route("createTeacherEducation")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddEducationResponseDto>>> CreateTeacherEducation(
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

    [Route("updateTeacherEducation")]
    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<UpdateEducationResponseDto>>> UpdateTeacherEducation(
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

    [Route("getTeacherEducation")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetTeacherEducationResponseDto>>> GetTeacherEducation(
        string teacherId)
    {
        try
        {
            var result = await _educationServices.GetTeacherEducation(teacherId);
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

    [Route("addTeacherSubject")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddTeacherSubjectResponseDto>>> AddTeacherSubject(
        [FromBody] AddTeacherSubjectRequestDto addTeacherSubjectRequestDto)
    {
        try
        {
            var result = await _teacherSubjectServices.AddTeacherSubject(addTeacherSubjectRequestDto);
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

    [Route("getTeacherSubject")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<GetTeacherSubjectResponseDto>>> GetTeacherSubject(string teacherId)
    {
        try
        {
            var result = await _teacherSubjectServices.GetTeacherSubject(teacherId);
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
    public async Task<ActionResult<ServiceResponse<GetSubjectListResponseDto>>> GetSearchedSubject(string? searchTerm)
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

    // Comments Controller

    [Route("addComment")]
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddCommentResponseDto>>> AddComment(
        AddCommentRequestDto addCommentRequestDto)
    {
        try
        {
            var result = await _commentServices.AddComment(addCommentRequestDto);
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

    [Route("getComments")]
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetCommentResponseDto>>>> GetComments(
        string teacherId)
    {
        try
        {
            var result = await _commentServices.GetCommentsList(teacherId);
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

    [Route("updateComment")]
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<UpdateCommentResponseDto>>> UpdateComment(
        UpdateCommentRequestDto updateCommentRequestDto)
    {
        try
        {
            var result = await _commentServices.UpdateComment(updateCommentRequestDto);
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