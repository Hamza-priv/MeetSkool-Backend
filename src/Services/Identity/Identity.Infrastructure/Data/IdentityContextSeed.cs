using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure.Data;

public class IdentityContextSeed
{
    public static async Task SeedAsync(IdentityDbContext context, ILogger<IdentityContextSeed> logger)
    {
        if (!context.Users.Any())
        {
            await context.SaveChangesAsync();

            logger.LogInformation($"Identity Api Database seeded.");
        }
    }
}