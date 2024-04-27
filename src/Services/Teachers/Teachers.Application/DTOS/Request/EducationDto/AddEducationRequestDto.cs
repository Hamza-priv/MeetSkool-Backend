namespace Teachers.Application.DTOS.Request.EducationDto;

public class AddEducationRequestDto
{
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
    public string? TeacherId { get; set; }
}