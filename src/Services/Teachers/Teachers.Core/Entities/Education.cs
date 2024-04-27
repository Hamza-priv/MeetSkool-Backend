namespace Teachers.Core.Entities;

public class Education
{
    public Guid EducationId { get; set; }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    public int? Semester { get; set; }
    public string? TeacherId { get; set; }
}