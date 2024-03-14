namespace Identity.Application.ViewModels;

public class MeetSkoolUser
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsTeacher { get; set; }
    public string? UserImage { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();

    public bool IsRememberMe { get; set; }

    public DateTime? CreatedDate { get; set; }
}