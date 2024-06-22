namespace Notification.Application.Services.Interfaces;

public interface ITokenServices
{
    Task<string> GenerateToken(string teacherId);
    Task<bool> GetToken(string token);
}