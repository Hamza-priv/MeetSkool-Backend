namespace Students.Core.Entities;

public class Education
{
    public Guid EducationId { get; set; }
    public string? InstituteName { get; set; }
    public string? Degree { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? StudentId { get; set; }
}