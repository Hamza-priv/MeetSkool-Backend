namespace Teachers.Application.DTOS.Request.TeacherDto;

public class AddTeacherRequestDto
{
    public required string TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? Descriptions { get; set; }
    public string? TotalOrder { get; set; }
}