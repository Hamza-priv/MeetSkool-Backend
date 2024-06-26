using Students.Application.DTOS.Response.SubjectDto;

namespace Students.Application.DTOS.Response.StudentDto;

public class GetAllInfoOfStudentResponseDto
{
    public string? Descriptions { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? TotalOrder { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
    public List<GetSubjectResponseDto>? Subjects { get; set; }
    public string? StudentName { get; set; }
    public string? StudentId { get; set; }
}