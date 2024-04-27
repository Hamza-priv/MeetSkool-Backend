namespace Teachers.Application.DTOS.Response.TeacherDto;

public class GetAllInfoOfTeacherResponseDto
{
    public string? Descriptions { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? TotalOrder { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
    public string? SubjectName { get; set; }
    public string? SubjectId { get; set; }
    public string? StudentName { get; set; }
}