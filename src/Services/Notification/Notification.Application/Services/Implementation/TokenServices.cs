using System.Security.Cryptography;
using System.Text;
using Notification.Application.Services.Interfaces;
using Notification.Core.Entities;
using Notification.Core.IRepository;

namespace Notification.Application.Services.Implementation;

public class TokenServices : ITokenServices
{
    private readonly IOrderTokenRepository _orderTokenRepository;

    public TokenServices(IOrderTokenRepository orderTokenRepository)
    {
        _orderTokenRepository = orderTokenRepository;
    }

    public async Task<string> GenerateToken(string teacherId)
    {
        try
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var data = new byte[12];
            using (var ran = RandomNumberGenerator.Create())
            {
                ran.GetBytes(data);
            }

            var result = new StringBuilder(12);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            await _orderTokenRepository.AddToken(result.ToString(), teacherId);
            return result.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> GetToken(string token)
    {
        try
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            var dbToken = await _orderTokenRepository.GetToken(token);
            return dbToken != null && dbToken.Token == token;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}