using AutoMapper;
using Identity.Application.ViewModels;
using Identity.Core.Entities;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Identity.Application.AccountServices;

public class ApplicationServices
{
    private readonly UserManager<MeetSkoolIdentityUser> _userManager;
    private readonly SignInManager<MeetSkoolIdentityUser> _signInManager;
    private readonly RoleManager<MeetSkoolIdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public ApplicationServices(UserManager<MeetSkoolIdentityUser> userManager,
        SignInManager<MeetSkoolIdentityUser> signInManager, RoleManager<MeetSkoolIdentityRole> roleManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<UserCreationResponse>> CreateUser(MeetSkoolUser user, string userRole)
    {
        var createUserResponse = new ServiceResponse<UserCreationResponse>
        {
            Data = new UserCreationResponse()
        };
        try
        {
            if (string.IsNullOrEmpty(userRole))
            {
                createUserResponse.Error.Add("User role is required");
                createUserResponse.Success = false;
                return createUserResponse;
            }

            user.Id = Guid.NewGuid();
            var appUser = _mapper.Map<MeetSkoolIdentityUser>(user);
            if (user is { Password: not null, Email: not null })
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    createUserResponse.Messages.Add("User Created Successfully");
                    if (createUserResponse.Data != null)
                    {
                        createUserResponse.Data.Code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                        createUserResponse.Data.UserId = appUser.Id;
                        createUserResponse.Data.Email = appUser.Email;

                        // Add userRole
                        var dbUser = await _userManager.FindByEmailAsync(user.Email);
                        if (dbUser is not null)
                        {
                            var addRoleResponse = await _userManager.AddToRoleAsync(dbUser, userRole);
                            if (addRoleResponse.Succeeded)
                            {
                                createUserResponse.Messages.Add("User Role Added Successfully");
                            }
                            else
                            {
                                addRoleResponse.Errors.ToList().ForEach(x =>
                                {
                                    createUserResponse.Error.Add(x.Description);
                                });
                                createUserResponse.Success = false;
                                createUserResponse.Data = null;
                            }
                        }
                    }
                }
                else
                {
                    result.Errors.ToList().ForEach(x => { createUserResponse.Error.Add(x.Description); });
                }
            }
            else
            {
                createUserResponse.Error.Add("Email and Password required");
                createUserResponse.Success = false;
                return createUserResponse;
            }
        }
        catch (Exception e)
        {
            createUserResponse.Error.Add(e.Message);
            createUserResponse.Success = false;
            return createUserResponse;
        }

        return createUserResponse;
    }

    public async Task<ServiceResponse<UserUpdateResponse>> UpdateUser(UpdateUser user)
    {
        var updateUserResponse = new ServiceResponse<UserUpdateResponse>
        {
            Data = new UserUpdateResponse()
        };

        try
        {
            if (user.Email != null)
            {
                var userToUpdate = await _userManager.FindByEmailAsync(user.Email);
                if (userToUpdate is not null)
                {
                    var updatedUser = _mapper.Map(user, userToUpdate);
                    var result = await _userManager.UpdateAsync(updatedUser);
                    if (result.Succeeded)
                    {
                        updateUserResponse.Data = _mapper.Map<UserUpdateResponse>(updatedUser);
                        updateUserResponse.Data.UserId = updatedUser.Id.ToString();
                        updateUserResponse.Messages.Add("User Updated Successfully");
                        return updateUserResponse;
                    }

                    result.Errors.ToList().ForEach(x => { updateUserResponse.Error.Add(x.Description); });
                    updateUserResponse.Success = false;
                    return updateUserResponse;
                }
            }
            else
            {
                updateUserResponse.Error.Add("Email can not be null");
                updateUserResponse.Success = false;
                return updateUserResponse;
            }
        }
        catch (Exception e)
        {
            updateUserResponse.Error.Add(e.Message);
            updateUserResponse.Success = false;
            return updateUserResponse;
        }

        return updateUserResponse;
    }

    public async Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword)
    {
        var changePasswordResponse = new ServiceResponse<UserCreationResponse>
        {
            Data = new UserCreationResponse()
        };
        try
        {
            if (changePassword.Email != null)
            {
                var user = await _userManager.FindByEmailAsync(changePassword.Email);
                if (user is not null)
                {
                    if (changePassword is { OldPassword: not null, NewPassword: not null })
                    {
                        var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword,
                            changePassword.NewPassword);

                        if (result.Succeeded)
                        {
                            changePasswordResponse.Messages.Add("Password Changed Successfully");
                            changePasswordResponse.Data.Email = changePassword.Email;
                            return changePasswordResponse;
                        }

                        result.Errors.ToList().ForEach(x => { changePasswordResponse.Error.Add(x.Description); });
                        changePasswordResponse.Success = false;
                        return changePasswordResponse;
                    }

                    changePasswordResponse.Error.Add("Passwords can not be null");
                    changePasswordResponse.Success = false;
                    return changePasswordResponse;
                }

                changePasswordResponse.Error.Add("Can not find user");
                changePasswordResponse.Success = false;
                return changePasswordResponse;
            }

            changePasswordResponse.Error.Add("Email can not be null");
            changePasswordResponse.Success = false;
            return changePasswordResponse;
        }
        catch (Exception e)
        {
            changePasswordResponse.Error.Add(e.Message);
            changePasswordResponse.Success = false;
            return changePasswordResponse;
        }
    }

    public async Task<ServiceResponse<UserSignInResponse>> PasswordSignInAsync(UserSignInModel signIn)
    {
        var response = new ServiceResponse<UserSignInResponse>
        {
            Data = new UserSignInResponse()
        };
        try
        {
            response = await PasswordSignIn(signIn);
            return response;
        }
        catch (Exception e)
        {
            response.Error.Add(e.Message);
            return response;
        }
    }

    public async Task<ServiceResponse<GeneratePasswordResetToken>> GeneratePasswordResetToken(string email)
    {
        var generatePasswordResetToken = new ServiceResponse<GeneratePasswordResetToken>
        {
            Data = new GeneratePasswordResetToken()
        };
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                generatePasswordResetToken.Data.UserId = user.Id;
                generatePasswordResetToken.Data.FullName = user.FullName;
                generatePasswordResetToken.Data.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                generatePasswordResetToken.Messages.Add("Password Token Generated");

                return generatePasswordResetToken;
            }
            else
            {
                generatePasswordResetToken.Success = false;
                generatePasswordResetToken.Error.Add("User not found");
                return generatePasswordResetToken;
            }
        }
        catch (Exception e)
        {
            generatePasswordResetToken.Error.Add(e.Message);
            generatePasswordResetToken.Success = false;
            return generatePasswordResetToken;
        }

    }

    public async Task<ServiceResponse<ResetPasswordResponse>> ResetPassword(string userId, string code, string password)
    {
        var passwordResetResponse = new ServiceResponse<ResetPasswordResponse>
        {
            Data = new ResetPasswordResponse()
        };
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, code, password);
                if (result.Succeeded)
                {
                    if (passwordResetResponse.Data != null)
                    {
                        passwordResetResponse.Data.FullName = user.FullName;
                        passwordResetResponse.Data.Email = user.Email;
                    }

                    passwordResetResponse.Messages.Add("Password Reset Successfully");
                    return passwordResetResponse;
                }

                result.Errors.ToList().ForEach(x => { passwordResetResponse.Error.Add(x.Description); });
                passwordResetResponse.Success = false;
                return passwordResetResponse;
            }

            passwordResetResponse.Error.Add("User not found");
            passwordResetResponse.Success = false;
            return passwordResetResponse;
        }
        catch (Exception e)
        {
            passwordResetResponse.Error.Add(e.Message);
            passwordResetResponse.Success = false;
            return passwordResetResponse;
        }
    }


    public async Task<ServiceResponse<ConfirmEmailResponse>> ConfirmEmail(string userId, string code)
    {
        var confirmEmailResponse = new ServiceResponse<ConfirmEmailResponse>
        {
            Data = new ConfirmEmailResponse()
        };
        try
        {
            /*
            var formattedToken = code.Replace(" ", "+");
            */
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                {
                    confirmEmailResponse.Data!.Email = user.Email;
                    confirmEmailResponse.Data.UserName = user.UserName;
                    confirmEmailResponse.Messages.Add("Email Confirmed Successfully");
                    return confirmEmailResponse;
                }

                result.Errors.ToList().ForEach(x => { confirmEmailResponse.Error.Add(x.Description); });
                confirmEmailResponse.Success = false;
                return confirmEmailResponse;
            }

            confirmEmailResponse.Error.Add("User not found");
            confirmEmailResponse.Success = false;
            return confirmEmailResponse;
        }
        catch (Exception e)
        {
            confirmEmailResponse.Error.Add(e.Message);
            confirmEmailResponse.Success = false;
            return confirmEmailResponse;
        }
    }

    public async Task<ServiceResponse<IdentityResult>> DeleteUser(string email)
    {
        var deleteUserResponse = new ServiceResponse<IdentityResult>();
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                deleteUserResponse.Data = await _userManager.DeleteAsync(user);
                if (deleteUserResponse.Data.Succeeded)
                {
                    deleteUserResponse.Messages.Add("User Deleted Successfully");
                    return deleteUserResponse;
                }

                deleteUserResponse.Success = false;
                deleteUserResponse.Error.Add("Can not delete user successfully");
                return deleteUserResponse;
            }

            deleteUserResponse.Success = false;
            deleteUserResponse.Error.Add("User not found");
            return deleteUserResponse;
        }
        catch (Exception e)
        {
            deleteUserResponse.Error.Add(e.Message);
            deleteUserResponse.Success = false;
            return deleteUserResponse;
        }
    }

    public async Task<ServiceResponse<int>> GetStudentsCount()
    {
        var studentCountResponse = new ServiceResponse<int>();
        try
        {
            var list = await GetStudentsList();
            if (list.Data is { Count: > 0 })
            {
                studentCountResponse.Data = list.Data.Count;
                studentCountResponse.Messages.Add("Students Count");
                return studentCountResponse;
            }

            studentCountResponse.Data = 0;
            studentCountResponse.Messages.Add("No Students");
        }
        catch (Exception e)
        {
            studentCountResponse.Success = false;
            studentCountResponse.Error.Add(e.Message);
        }

        return studentCountResponse;
    }

    public async Task<ServiceResponse<List<MeetSkoolUser>>> GetStudentsList()
    {
        var studentList = new ServiceResponse<List<MeetSkoolUser>>();
        try
        {
            var students = await _userManager.GetUsersInRoleAsync(Constants.Student);
            if (students.Count > 0)
            {
                studentList.Data = _mapper.Map<List<MeetSkoolUser>>(students);
                studentList.Messages.Add("Students List");
                return studentList;
            }

            studentList.Error.Add("No Students Found");
            studentList.Success = false;
            return studentList;
        }
        catch (Exception e)
        {
            studentList.Error.Add(e.Message);
            studentList.Success = false;
            return studentList;
        }
    }

    public async Task<ServiceResponse<int>> GetTeachersCount()
    {
        var teacherCountResponse = new ServiceResponse<int>();
        try
        {
            var list = await GetTeachersList();
            if (list.Data is { Count: > 0 })
            {
                teacherCountResponse.Data = list.Data.Count;
                teacherCountResponse.Messages.Add("Teachers Count");
                return teacherCountResponse;
            }

            teacherCountResponse.Data = 0;
            teacherCountResponse.Messages.Add("No teachers");
        }
        catch (Exception e)
        {
            teacherCountResponse.Success = false;
            teacherCountResponse.Error.Add(e.Message);
        }

        return teacherCountResponse;
    }


    public async Task<ServiceResponse<List<MeetSkoolUser>>> GetTeachersList()
    {
        var teachersList = new ServiceResponse<List<MeetSkoolUser>>();
        try
        {
            var teachers = await _userManager.GetUsersInRoleAsync(Constants.Teacher);
            if (teachers.Count > 0)
            {
                teachersList.Data = _mapper.Map<List<MeetSkoolUser>>(teachers);
                teachersList.Messages.Add("Teachers List");
                return teachersList;
            }

            teachersList.Error.Add("No Teachers Found");
            teachersList.Success = false;
            return teachersList;
        }
        catch (Exception e)
        {
            teachersList.Error.Add(e.Message);
            teachersList.Success = false;
            return teachersList;
        }
    }

    public async Task<ServiceResponse<List<string>>?> GetUserRoles(string email)
    {
        var userRoleResponse = new ServiceResponse<List<string>>();
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                userRoleResponse.Data = (List<string>)await _userManager.GetRolesAsync(user);
                userRoleResponse.Messages.Add("User Roles");
                return userRoleResponse;
            }

            userRoleResponse.Error.Add("User not found");
            userRoleResponse.Success = false;
            return userRoleResponse;
        }
        catch (Exception e)
        {
            userRoleResponse.Error.Add(e.Message);
            userRoleResponse.Success = false;
            return userRoleResponse;
        }
    }

    public async Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email)
    {
        var findUserResponse = new ServiceResponse<MeetSkoolUser>();
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                findUserResponse.Data = _mapper.Map<MeetSkoolUser>(user);
                findUserResponse.Messages.Add("User Found");
                return findUserResponse;
            }

            findUserResponse.Error.Add("User not found");
            findUserResponse.Success = false;
            return findUserResponse;
        }
        catch (Exception e)
        {
            findUserResponse.Error.Add(e.Message);
            findUserResponse.Success = false;
            return findUserResponse;
        }
    }

    private async Task<ServiceResponse<UserSignInResponse>> PasswordSignIn(UserSignInModel user)
    {
        var signInResponse = new ServiceResponse<UserSignInResponse>()
        {
            Data = new UserSignInResponse()
        };
        try
        {
            if (user is { Email: not null, Password: not null })
            {
                signInResponse.Data.SignInResult =
                    await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
                if (!signInResponse.Data.SignInResult.Succeeded)
                {
                    signInResponse.Success = false;
                    signInResponse.Error.Add("Invalid Credentials");
                    return signInResponse;
                }

                var userInfo = await _userManager.FindByEmailAsync(user.Email);
                signInResponse.Data.UserInfo = _mapper.Map<UserInfo>(userInfo);
                signInResponse.Data.UserRoles = await GetUserRoles(user.Email);
                signInResponse.Messages.Add("User Signed In");

                var client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    { "username", user.Email },
                    { "password", user.Password },
                    { "client_id", "client" },
                    { "scope", "MeetSkool" },
                    { "grant_type", "password" },
                    { "client_secret", "secret" }
                };

                var content = new FormUrlEncodedContent(values);
                var responseToken = await client.PostAsync("http://localhost:5062/connect/token", content);
                var accessToken = await responseToken.Content.ReadAsStringAsync();
                signInResponse.Data.AccessToken = JsonConvert.DeserializeObject<AccessTokenModel>(accessToken);

                return signInResponse;
            }

            signInResponse.Success = false;
            signInResponse.Error.Add("Email and password is required");
            return signInResponse;
        }
        catch (Exception e)
        {
            signInResponse.Error.Add(e.Message);
            signInResponse.Success = false;
            return signInResponse;
        }
    }
}