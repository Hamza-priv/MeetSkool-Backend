namespace Students.Application.DTOS.Request.EducationDto;

public class UpdateEducationRequestDto
{
    public string? StudentId { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
}