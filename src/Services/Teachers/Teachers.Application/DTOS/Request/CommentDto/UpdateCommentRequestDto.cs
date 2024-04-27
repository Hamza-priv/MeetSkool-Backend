namespace Teachers.Application.DTOS.Request.CommentDto;

public class UpdateCommentRequestDto
{
    public string? Comment { get; set; }
    public Guid CommentId { get; set; }
}