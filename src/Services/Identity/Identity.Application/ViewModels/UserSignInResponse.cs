using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.ViewModels;

public class UserSignInResponse
{
    public ServiceResponse<List<string>>? UserRoles { get; set; }
    public UserInfo? UserInfo { get; set; }
    public SignInResult? SignInResult { get; set; }
    public AccessTokenModel? AccessToken { get; set; }
    public string? ErrorMessage { get; set; }
}

public abstract class AccessTokenModel
{
    public string? AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string? TokenType { get; set; }
    public string? Scope { get; set; }
}

public class UserInfo
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Guid Id { get; set; }
}