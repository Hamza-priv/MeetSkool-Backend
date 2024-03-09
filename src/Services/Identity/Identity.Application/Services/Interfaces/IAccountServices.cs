using Identity.Application.ViewModels;

namespace Identity.Application.Services.Interfaces;

public interface IAccountServices
{
    Task<UserCreationResponse> CreateUser(MeetSkoolUser user);
    Task<UserCreationResponse> UpdateUser(MeetSkoolUser user);
    Task<UserCreationResponse> ChangePassword(ChangePassword changePassword);
    Task<MeetSkoolUser> FindByEmail(string email);

    /*Task<List<Models.ApplicationUser>> getBusinessOwnerUser();
    Task<List<Models.ApplicationUser>> getUser();*/
    /*
    Task<SignInResult> PasswordSignInAsync(ViewModels.UserSignInModel user);
    */
    Task<List<string>> GetUserRoles(string email);

    /*
    Task<IdentityResult> deleteUserAsync(string emailorId);
    */
    Task<ResetPasswordResponse> ConfirmEmail(string userId, string code);

    Task<GeneratePasswordResetTokenResponse> GeneratePasswordResetToken(string email);
    /*Task<int> getUserCount();

    Task<int> getBusinessOwnerUserCount();*/
}