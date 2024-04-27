namespace Teachers.Core.Entities;

public class Comments
{
    public Guid CommentId { get; set; }
    public string? Comment { get; set; }
    public string? TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? StudentName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
}