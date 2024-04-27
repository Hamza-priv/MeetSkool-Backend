using Microsoft.Extensions.Logging;

namespace Teachers.Infrastructure.Data;

public class TeacherDbContextSeed
{
    public static async Task SeedAsync(TeacherDbContext context, ILogger<TeacherDbContextSeed> logger)
    {
        if (!context.Teachers.Any())
        {
            await context.SaveChangesAsync();
            logger.LogInformation($"Teacher Api Database seeded.");
        }
    }
}