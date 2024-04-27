namespace Teachers.Application.DTOS.Request.EducationDto;

public class UpdateEducationRequestDto
{
    public string? TeacherId { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
}