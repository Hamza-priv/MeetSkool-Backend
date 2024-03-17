namespace Identity.Application.Services.Interfaces;

public interface IEmailServices
{
    Task<bool> SendConfirmAccount(Guid userId, string code, string? userName, string email);
    Task<bool> ResendConfirmAccount(Guid userId, string code, string email, string userName);
    Task<bool> SendForgetPassword(Guid userId, string token, string userName, string email);
    Task<bool> PasswordChangedNotification(string userId, string code, string password, string userName, string email);
    Task<bool> EmailConfirmedNotification(string userId, string userName, string email);
}