using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;
using Identity.Infrastructure;

namespace Identity.Application.Services.Implementation;

public class AccountServices : IAccountServices
{
    public async Task<UserCreationResponse> CreateUser(MeetSkoolUser user)
    {
        return await CreateUserInternal(user, user.IsTeacher ? Constants.Teacher : Constants.Student);
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
    
    // create user Internal function 

    private async Task<UserCreationResponse> CreateUserInternal(MeetSkoolUser user, string userType)
    {
        try
        {
            if (string.IsNullOrEmpty(userType))
            {
                throw new System.Exception("Role is required");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        throw new NotImplementedException();
    }
}