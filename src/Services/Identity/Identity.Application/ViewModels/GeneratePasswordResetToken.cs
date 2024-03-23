namespace Identity.Application.ViewModels;

public class GeneratePasswordResetToken
{
    public Guid UserId { get; set; }
    public string? Token { get; set; }
    public string? FullName { get; set; }
}