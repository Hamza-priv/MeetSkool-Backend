namespace Teachers.Application.DTOS.Request.TeacherSubjectDto;

public class AddTeacherSubjectRequestDto
{
    public string? TeacherId { get; set; }
    public Guid SubjectId { get; set; }
}