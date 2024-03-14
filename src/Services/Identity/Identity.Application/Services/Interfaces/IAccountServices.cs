﻿using Identity.Application.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Services.Interfaces;

public interface IAccountServices
{
    Task<ServiceResponse<UserCreationResponse>> CreateUser(MeetSkoolUser user);
    Task<ServiceResponse<UserCreationResponse>> UpdateUser(MeetSkoolUser user);
    Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword);
    Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email);

    Task<ServiceResponse<List<MeetSkoolUser>>> GetTeachersList();
    Task<ServiceResponse<List<MeetSkoolUser>>> GetStudentsList();
    Task<ServiceResponse<SignInResult>> PasswordSignInAsync(UserSignInModel signIn);
    Task<ServiceResponse<List<string>>> GetUserRoles(string email);

    Task<ServiceResponse<IdentityResult>> DeleteUser(string email);
    Task<ServiceResponse<ConfirmEmailResponse>> ConfirmEmail(string userId, string code);

    Task<ServiceResponse<GeneratePasswordResetTokenResponse>> GeneratePasswordResetToken(string email);
    Task<ServiceResponse<int>> GetTeachersCount();
    Task<ServiceResponse<int>> GetStudentsCount();
}