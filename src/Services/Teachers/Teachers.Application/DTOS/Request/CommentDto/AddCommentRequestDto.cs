namespace Teachers.Application.DTOS.Request.CommentDto;

public class AddCommentRequestDto
{
    public string? Comment { get; set; }
    public string? TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? StudentName { get; set; }
}