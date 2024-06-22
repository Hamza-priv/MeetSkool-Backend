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
            _notificationDbContext.OrderTokens.Add(new OrderToken() { Token = token, Teacher = teacherId});
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
            return await _notificationDbContext.OrderTokens.FirstOrDefaultAsync(x => x != null && x.Token == token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}