using AutoMapper;
using Teachers.Application.DTOS.Request.CommentDto;
using Teachers.Application.DTOS.Response.CommentDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;

namespace Teachers.Application.Services.Implementation;

public class CommentServices : ICommentServices
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentServices(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AddCommentResponseDto>> AddComment(AddCommentRequestDto addComment)
    {
        var addCommentResponse = new ServiceResponse<AddCommentResponseDto>()
        {
            Data = new AddCommentResponseDto()
        };
        try
        {
            var comment = _mapper.Map<Comments>(addComment);
            var result = await _commentRepository.AddAsync(comment);
            if (result != null)
            {
                addCommentResponse.Data.Comment = result.Comment;
                addCommentResponse.Data.CommentId = result.CommentId.ToString();
                addCommentResponse.Messages.Add("Comment added successfully");
                return addCommentResponse;
            }

            addCommentResponse.Error.Add("Comment not added");
            addCommentResponse.Success = false;
            return addCommentResponse;
        }
        catch (Exception e)
        {
            addCommentResponse.Error.Add(e.Message);
            addCommentResponse.Success = false;
            return addCommentResponse;
        }
    }

    public async Task<ServiceResponse<List<GetCommentResponseDto>>> GetCommentsList(string teacherId)
    {
        // need implementation in repo
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<UpdateCommentResponseDto>> UpdateComment(UpdateCommentRequestDto updateComment)
    {
        var updateCommentResponse = new ServiceResponse<UpdateCommentResponseDto>()
        {
            Data = new UpdateCommentResponseDto()
        };
        try
        {
            var dbComment = await _commentRepository.GetByIdAsync(updateComment.CommentId);
            if (dbComment != null)
            {
                var newComment = _mapper.Map(dbComment, updateComment);
                var updatedComment = _mapper.Map<Comments>(newComment);
                var result = await _commentRepository.UpdateAsync(updatedComment);
                if (result != null)
                {
                    updateCommentResponse.Data.Comment = result.Comment;
                    updateCommentResponse.Data.CommentId = result.CommentId.ToString();
                    updateCommentResponse.Messages.Add("Comment updated successfully");
                    return updateCommentResponse;
                }

                updateCommentResponse.Error.Add("Comment not updated");
                updateCommentResponse.Success = false;
                return updateCommentResponse;
            }

            updateCommentResponse.Error.Add("Comment not found");
            updateCommentResponse.Success = false;
            return updateCommentResponse;
        }
        catch (Exception e)
        {
            updateCommentResponse.Error.Add(e.Message);
            updateCommentResponse.Success = false;
            return updateCommentResponse;
        }
    }
}