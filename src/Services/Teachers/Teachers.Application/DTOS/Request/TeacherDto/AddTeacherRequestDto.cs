namespace Teachers.Application.DTOS.Request.TeacherDto;

public class AddTeacherRequestDto
{
    public required string TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? Description { get; set; }
    public string? TotalOrderCompleted { get; set; }
}