namespace Teachers.Application.DTOS.Response.EducationDto;

public class GetTeacherEducationResponseDto
{
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
}