using Microsoft.EntityFrameworkCore;
using Notification.Core.Entities;

namespace Notification.Infrastructure.Data;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
    {
    }

    public DbSet<OrderToken> OrderTokens { get; set; }
}