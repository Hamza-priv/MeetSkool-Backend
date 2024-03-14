﻿using Identity.Application.AccountServices;
using Identity.Application.Services.Interfaces;
using Identity.Application.ViewModels;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;

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
        try
        {
            return await _applicationServices.CreateUser(user, user.IsTeacher ? Constants.Teacher : Constants.Student);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<UserCreationResponse>> UpdateUser(MeetSkoolUser user)
    {
        try
        {
            return await _applicationServices.UpdateUser(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<UserCreationResponse>> ChangePassword(ChangePassword changePassword)
    {
        try
        {
            return await _applicationServices.ChangePassword(changePassword);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<MeetSkoolUser>> FindByEmail(string email)
    {
        try
        {
            return await _applicationServices.FindByEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<List<MeetSkoolUser>>> GetTeachersList()
    {
        try
        {
            return await _applicationServices.GetTeachersList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<List<MeetSkoolUser>>> GetStudentsList()
    {
        try
        {
            return await _applicationServices.GetStudentsList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<SignInResult>> PasswordSignInAsync(UserSignInModel signIn)
    {
        try
        {
            return await _applicationServices.PasswordSignInAsync(signIn);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<List<string>>> GetUserRoles(string email)
    {
        try
        {
            return await _applicationServices.GetUserRoles(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<IdentityResult>> DeleteUser(string email)
    {
        try
        {
            return await _applicationServices.DeleteUser(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<ConfirmEmailResponse>> ConfirmEmail(string userId, string code)
    {
        try
        {
            return await _applicationServices.ConfirmEmail(userId, code);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<GeneratePasswordResetTokenResponse>> GeneratePasswordResetToken(string email)
    {
        try
        {
            return await _applicationServices.GeneratePasswordResetToken(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<int>> GetTeachersCount()
    {
        try
        {
            return await _applicationServices.GetTeachersCount();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<int>> GetStudentsCount()
    {
        try
        {
            return await _applicationServices.GetStudentsCount();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}