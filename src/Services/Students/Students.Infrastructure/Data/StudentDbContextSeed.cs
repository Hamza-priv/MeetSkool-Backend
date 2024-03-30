using Microsoft.Extensions.Logging;

namespace Students.Infrastructure.Data;

public class StudentDbContextSeed
{
    public static async Task SeedAsync(StudentDbContext context, ILogger<StudentDbContextSeed> logger)
    {
        if (!context.Students.Any())
        {
            await context.SaveChangesAsync();
            logger.LogInformation($"Customer App Database seeded.");
        }
    }
}