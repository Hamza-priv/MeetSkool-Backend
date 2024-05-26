using Identity.Application.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Services.Interfaces;

public interface IAccountServices
{
    Task<ServiceResponse<UserCreationResponse>> CreateUser(MeetSkoolUser user);
    Task<ServiceResponse<UserUpdateResponse>> UpdateUser(UpdateUser user);
    Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword);
    Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email);

    Task<ServiceResponse<List<MeetSkoolUser>>> GetTeachersList();
    Task<ServiceResponse<List<MeetSkoolUser>>> GetStudentsList();
    Task<ServiceResponse<UserSignInResponse>> PasswordSignInAsync(UserSignInModel signIn);
    Task<ServiceResponse<List<string>>?> GetUserRoles(string email);

    Task<ServiceResponse<IdentityResult>> DeleteUser(string email);
    Task<ServiceResponse<ConfirmEmailResponse>> ConfirmEmail(string userId, string code);

    Task<ServiceResponse<GeneratePasswordResetToken>> GeneratePasswordResetToken(string email);
    Task<ServiceResponse<int>> GetTeachersCount();
    Task<ServiceResponse<int>> GetStudentsCount();
    Task<ServiceResponse<ResetPasswordResponse>> ResetPassword(string userId, string code, string newPassword);
    Task<bool> IsEmailConfirmed(Guid userId);
}