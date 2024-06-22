using Teachers.Application.DTOS.Response.SubjectDto;

namespace Teachers.Application.DTOS.Response.TeacherDto;

public class GetAllInfoOfTeacherResponseDto
{
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? TotalOrderCompleted { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
    public List<GetSubjectResponseDto>? Subjects { get; set; }
    public string? TeacherName { get; set; }
}