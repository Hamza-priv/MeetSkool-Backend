namespace Identity.Application.ViewModels;

public class GeneratePasswordResetTokenResponse
{
    public Guid UserId { get; set; }
    public string? Token { get; set; }
    public string? FullName { get; set; }
    
}