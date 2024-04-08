namespace Students.Application.DTOS.Request.StudentDto;

public class AddStudentRequestDto
{
    public required string StudentId { get; set; }
    public string? StudentName { get; set; }
    public string? Descriptions { get; set; }
    public string? TotalOrder { get; set; }
}