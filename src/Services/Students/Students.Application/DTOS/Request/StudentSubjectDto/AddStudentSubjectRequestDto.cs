namespace Students.Application.DTOS.Request.StudentSubjectDto;

public class AddStudentSubjectRequestDto
{
    public string? StudentId { get; set; }
    public Guid SubjectId { get; set; }
}