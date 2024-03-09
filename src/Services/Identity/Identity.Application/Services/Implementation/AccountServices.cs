using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;

namespace Identity.Application.Services.Implementation;

public class AccountServices : IAccountServices
{
    public async Task<UserCreationResponse> CreateUser(MeetSkoolUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCreationResponse> UpdateUser(MeetSkoolUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCreationResponse> ChangePassword(ChangePassword changePassword)
    {
        throw new NotImplementedException();
    }

    public async Task<MeetSkoolUser> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> GetUserRoles(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ResetPasswordResponse> ConfirmEmail(string userId, string code)
    {
        throw new NotImplementedException();
    }

    public async Task<GeneratePasswordResetTokenResponse> GeneratePasswordResetToken(string email)
    {
        throw new NotImplementedException();
    }
}