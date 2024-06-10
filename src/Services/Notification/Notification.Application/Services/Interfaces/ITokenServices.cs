namespace Notification.Application.Services.Interfaces;

public interface ITokenServices
{
    Task<string> GenerateToken();
    Task<bool> GetToken(string token);
}