namespace Students.Application.DTOS.Request.StudentDto;

public class AddStudentRequestDto
{
    public required string StudentId { get; set; }
    public string? Descriptions { get; set; }
    public List<string>? Subjects { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? TotalOrder { get; set; }
}