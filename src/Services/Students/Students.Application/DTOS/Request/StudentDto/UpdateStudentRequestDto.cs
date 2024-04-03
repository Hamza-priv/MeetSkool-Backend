namespace Students.Application.DTOS.Request.StudentDto;

public class UpdateStudentRequestDto
{
    public string? StudentId { get; set; }
    public string? Descriptions { get; set; }
    public List<string>? Subjects { get; set; } = new List<string>();
    public string? TotalOrder { get; set; }
}