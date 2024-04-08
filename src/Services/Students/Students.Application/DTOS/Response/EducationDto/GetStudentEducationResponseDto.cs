namespace Students.Application.DTOS.Response.EducationDto;

public class GetStudentEducationResponseDto
{
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
}