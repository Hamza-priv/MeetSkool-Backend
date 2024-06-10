namespace Identity.Application.ViewModels;

public class UserCreationResponse
{
    public string? Email { get; set; }
    public string? Code { get; set; }
    public Guid UserId { get; set; }
    
    public AccessTokenModel? AccessToken { get; set; }
}