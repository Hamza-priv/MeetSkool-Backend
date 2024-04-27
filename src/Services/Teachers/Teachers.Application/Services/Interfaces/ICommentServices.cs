using Teachers.Application.DTOS.Request.CommentDto;
using Teachers.Application.DTOS.Response.CommentDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface ICommentServices
{
    Task<ServiceResponse<AddCommentResponseDto>> AddComment(AddCommentRequestDto addComment);
    Task<ServiceResponse<List<GetCommentResponseDto>>> GetCommentsList(string teacherId);
    Task<ServiceResponse<UpdateCommentResponseDto>> UpdateComment(UpdateCommentRequestDto updateComment);
}