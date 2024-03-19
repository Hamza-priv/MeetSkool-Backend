using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Identity.Application.ViewModels;

public class UserSignInResponse
{
    public ServiceResponse<List<string>>? UserRoles { get; set; }
    public UserInfo? UserInfo { get; set; }
    public SignInResult? SignInResult { get; set; }
    public AccessTokenModel? AccessToken { get; set; }

    public string? ErrorMessage { get; set; }
}

public class AccessTokenModel
{
    [JsonProperty("access_token")] public string? AccessToken { get; set; }

    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

    [JsonProperty("token_type")] public string? TokenType { get; set; }

    [JsonProperty("scope")] public string? Scope { get; set; }
}

public class UserInfo
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Guid Id { get; set; }
}