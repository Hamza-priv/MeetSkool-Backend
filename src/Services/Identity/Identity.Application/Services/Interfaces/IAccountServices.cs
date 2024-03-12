using Identity.Application.ViewModels;

namespace Identity.Application.Services.Interfaces;

public interface IAccountServices
{
    Task<ServiceResponse<UserCreationResponse>> CreateUser(MeetSkoolUser user);
    Task<ServiceResponse<UserCreationResponse>> UpdateUser(MeetSkoolUser user);
    Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword);
    Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email);

    /*Task<List<Models.ApplicationUser>> getBusinessOwnerUser();
    Task<List<Models.ApplicationUser>> getUser();*/
    /*
    Task<SignInResult> PasswordSignInAsync(ViewModels.UserSignInModel user);
    */
    Task<ServiceResponse<List<string>>> GetUserRoles(string email);

    /*
    Task<IdentityResult> deleteUserAsync(string emailorId);
    */
    Task<ServiceResponse<ResetPasswordResponse>> ConfirmEmail(string userId, string code);

    Task<ServiceResponse<GeneratePasswordResetTokenResponse>> GeneratePasswordResetToken(string email);
    /*Task<int> getUserCount();

    Task<int> getBusinessOwnerUserCount();*/
}