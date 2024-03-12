using Identity.Application.AccountServices;
using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;
using Identity.Infrastructure;

namespace Identity.Application.Services.Implementation;

public class AccountServices : IAccountServices
{
    private readonly ApplicationServices _applicationServices;

    public AccountServices(ApplicationServices applicationServices)
    {
        _applicationServices = applicationServices;
    }


    public async Task<ServiceResponse<UserCreationResponse>> CreateUser(MeetSkoolUser user)
    {
        return await _applicationServices.CreateUser(user, user.IsTeacher ? Constants.Teacher : Constants.Student);
    }

    public async Task<ServiceResponse<UserCreationResponse>> UpdateUser(MeetSkoolUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<string>>> GetUserRoles(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ResetPasswordResponse>> ConfirmEmail(string userId, string code)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GeneratePasswordResetTokenResponse>> GeneratePasswordResetToken(string email)
    {
        throw new NotImplementedException();
    }
}