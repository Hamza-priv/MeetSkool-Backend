using System.Net;
using System.Net.Mail;
using Azure;
using Identity.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Identity.Application.Services.Implementation;

public class EmailServices : IEmailServices
{
    // call back urls need to be done later on

    private readonly IConfiguration _configuration;

    public EmailServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> SendConfirmAccount(Guid userId, string code, string? userName, string email)
    {
        try
        {
            var callbackUrl = "http://localhost:5173/Account/ConfirmEmail?userId=" + userId + "&code=" + code;
            var path = Path.Combine(@"EmailTemplates\SendAccountConfirmation.html");
            var check = await SendEmail(callbackUrl, path, email, "Confirm your account",
                userName);
            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> ResendConfirmAccount(Guid userId, string code, string email, string userName)
    {
        try
        {
            var callbackUrl = "https://localhost:7063/Account/ConfirmEmail?userId=" + userId + "&code=" + code;
            var path = Path.Combine(@"EmailTemplates\SendAccountConfirmation.html");
            var check = await SendEmail(callbackUrl, path, email, "Confirm your account",
                userName);
            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> SendForgetPassword(Guid userId, string token, string userName, string email)
    {
        try
        {
            var callbackUrl = "http://localhost:5173/Account/ResetPassword?userId=" + userId + "&code=" + token;
            var path = Path.Combine(@"EmailTemplates\SendForgotPassword.html");
            var check = await SendEmail(callbackUrl, path, email, "Forget Password",
                userName);
            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> PasswordChangedNotification(string userId, string code, string password, string userName,
        string email)
    {
        try
        {
            const string callbackUrl = "https://localhost:7063/Account/Login";
            var path = Path.Combine(@"EmailTemplates\SendResetPasswordNotification.html");
            var check = await SendEmail(callbackUrl, path, email, "Password is Changed",
                userName);
            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> EmailConfirmedNotification(string userId, string userName, string email)
    {
        try
        {
            const string callbackUrl = "https://localhost:7063/Account/LoginPage";
            var path = Path.Combine(@"EmailTemplates\SendEmailConfirmedNotification.html");
            var check = await SendEmail(callbackUrl, path, email, "Your Account is Confirmed", userName);
            return check;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    //change path

    public async Task OrderSentEmail(string userId, string userName, string email)
    {
        try
        {
            var path = Path.Combine(@"EmailTemplates\SendEmailConfirmedNotification.html");
            _ = await SendEmail("", path, email, "Your Order is Sent", userName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task OrderConfirmedEmail(string userId, string userName, string email)
    {
        try
        {
            var path = Path.Combine(@"EmailTemplates\SendEmailConfirmedNotification.html");
            _ = await SendEmail("", path, email, "Your Order is Confirmed", userName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task OrderCancelEmail(string userId, string userName, string email)
    {
        try
        {
            var path = Path.Combine(@"EmailTemplates\SendEmailConfirmedNotification.html");
            _ = await SendEmail("", path, email, "Your Order is Canceled", userName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task OrderCompleteEmail(string userId, string userName, string email)
    {
        try
        {
            var path = Path.Combine(@"EmailTemplates\SendEmailConfirmedNotification.html");
            _ = await SendEmail("", path, email, "Your Order is Complete", userName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<bool> SendEmail(string? callBackUrl, string path, string recipientEmail, string subject,
        string? userName)
    {
        var template = string.Empty;
        if (System.IO.File.Exists(path))
        {
            template = await System.IO.File.ReadAllTextAsync(path);
            template = template.Replace("{$href}", callBackUrl);
            template = template.Replace("{$firstname}", userName);
        }

        var check = await InternalSendEmail(recipientEmail, subject, template);
        return check;
    }

    private async Task<bool> InternalSendEmail(string recipientEmail, string subject, string message)
    {
        var host = _configuration.GetSection("Email")["Host"];
        var port = _configuration.GetSection("Email")["Port"];
        var username = _configuration.GetSection("Email")["Username"];
        var password = _configuration.GetSection("Email")["Password"];
        var from = _configuration.GetSection("Email")["from"];

        if (port == null) return false;
        using var client = new SmtpClient(host, int.Parse(port));
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(username, password);
        client.EnableSsl = true;

        using var mailMessage = new MailMessage();
        if (from != null) mailMessage.From = new MailAddress(from);
        mailMessage.To.Add(recipientEmail);
        mailMessage.Subject = subject;
        mailMessage.Body = message;
        mailMessage.IsBodyHtml = true;

        try
        {
            await client.SendMailAsync(mailMessage);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error sending email: {e.Message}");
            return false;
        }
    }
}