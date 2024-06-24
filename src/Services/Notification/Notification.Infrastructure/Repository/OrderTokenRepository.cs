using Microsoft.EntityFrameworkCore;
using Notification.Core.Entities;
using Notification.Core.IRepository;
using Notification.Infrastructure.Data;

namespace Notification.Infrastructure.Repository;

public class OrderTokenRepository : IOrderTokenRepository
{
    private readonly NotificationDbContext _notificationDbContext;

    public OrderTokenRepository(NotificationDbContext notificationDbContext)
    {
        _notificationDbContext = notificationDbContext;
    }

    public async Task AddToken(string token, string teacherId)
    {
        try
        {
            _notificationDbContext.OrderTokens.Add(new OrderToken() { Token = token, Teacher = teacherId });
            await _notificationDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<OrderToken?> GetToken(string token)
    {
        try
        {
            var dbToken = await _notificationDbContext.OrderTokens.FirstOrDefaultAsync(x => x.Token == token);
            if (dbToken == null) return dbToken;
            dbToken.Confirmed = true;
            _notificationDbContext.OrderTokens.Update(dbToken);
            await _notificationDbContext.SaveChangesAsync();
            return dbToken;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<string?>> Get24HourOldToken()
    {
        try
        {
            return await _notificationDbContext.OrderTokens
                .Where(x => x.CreatedDate >= DateTime.Now.AddHours(-24).ToLocalTime() && x.Confirmed == false)
                .Select(x => x.Teacher)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<string?>> Get48HourOldToken()
    {
        try
        {
            return await _notificationDbContext.OrderTokens
                .Where(x => x.CreatedDate >= DateTime.Now.AddHours(-48).ToLocalTime() && x.Confirmed == false)
                .Select(x => x.Teacher)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<string?>> Get72HourOldToken()
    {
        try
        {
            return await _notificationDbContext.OrderTokens
                .Where(x => x.CreatedDate >= DateTime.Now.AddHours(-72).ToLocalTime() && x.Confirmed == false)
                .Select(x => x.Teacher)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}