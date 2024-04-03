namespace Students.Application.DTOS.Request.EducationDto;

public class UpdateEducationRequestDto
{
    public string? EducationId { get; set; }
    public string? InstituteName { get; set; }
    public string? Degree { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
}