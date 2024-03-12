using AutoMapper;
using Identity.Application.ViewModels;
using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

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
        var createUserResponse = new ServiceResponse<UserCreationResponse>();
        try
        {
            if (string.IsNullOrEmpty(userRole))
            {
                createUserResponse.Error.Add("User role is required");
                createUserResponse.Success = false;
                return createUserResponse;
            }

            var appUser = _mapper.Map<MeetSkoolIdentityUser>(user);
            if (user is { Password: not null, Email: not null })
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    createUserResponse.Messages.Add("User Created Successfully");
                    createUserResponse.Data!.Code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
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

    public async Task<ServiceResponse<UserCreationResponse>> UpdateUser(MeetSkoolUser user)
    {
        var updateUserResponse = new ServiceResponse<UserCreationResponse>();

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
                        updateUserResponse.Data = _mapper.Map<UserCreationResponse>(updatedUser);
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
        var changePasswordResponse = new ServiceResponse<UserCreationResponse>();
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

    public async Task<SignInResult> PasswordSignInAsync(UserSignInModel signIn)
    {
        try
        {
            if (signIn is { Email: not null, Password: not null })
                return await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, true, false);
            return new SignInResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<GeneratePasswordResetTokenResponse>> GeneratePasswordResetToken(string email)
    {
        var passwordResetResponse = new ServiceResponse<GeneratePasswordResetTokenResponse>();
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (passwordResetResponse.Data != null)
                {
                    passwordResetResponse.Data.UserId = user.Id;
                    passwordResetResponse.Data.FullName = user.FullName;
                    passwordResetResponse.Data.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    passwordResetResponse.Messages.Add("Password Token Generated");

                    return passwordResetResponse;
                }
            }
            else
            {
                passwordResetResponse.Success = false;
                passwordResetResponse.Error.Add("User not found");
                return passwordResetResponse;
            }
        }
        catch (Exception e)
        {
            passwordResetResponse.Error.Add(e.Message);
            passwordResetResponse.Success = false;
            return passwordResetResponse;
        }

        return passwordResetResponse;
    }
}