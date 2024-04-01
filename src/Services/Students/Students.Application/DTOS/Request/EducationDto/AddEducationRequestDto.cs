namespace Students.Application.DTOS.Request.EducationDto;

public class AddEducationRequestDto
{
    public string? InstituteName { get; set; }
    public string? Degree { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? StudentId { get; set; }
}