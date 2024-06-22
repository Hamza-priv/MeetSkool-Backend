using Microsoft.Extensions.Logging;

namespace Notification.Infrastructure.Data;

public class NotificationDbContextSeed
{
    public static async Task SeedAsync(NotificationDbContext context, ILogger<NotificationDbContextSeed> logger)
    {
        if (!context.OrderTokens.Any())
        {
            await context.SaveChangesAsync();
            logger.LogInformation($"Notification Api Database seeded.");
        }
    }
}