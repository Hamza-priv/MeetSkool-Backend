using Microsoft.Extensions.Logging;

namespace Chat.Infrastructure.Data;

public class ChatDbContextSeed
{
    public static async Task SeedAsync(ChatDbContext context, ILogger<ChatDbContext> logger)
    {
        if (!context.Messages.Any())
        {
            await context.SaveChangesAsync();
            logger.LogInformation($"Chat Api Database seeded.");
        }
    }
}