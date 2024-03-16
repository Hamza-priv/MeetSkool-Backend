using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions;

public static class DbExtension
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
        where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetService<TContext>();

        try
        {
            logger.LogInformation("Db Migration Started: {Name}", typeof(TContext).Name);

            if (context is not null)
            {
                context.Database.Migrate();
                seeder(context, services);
                
                logger.LogInformation("Db Migration Succeeded: {Name}", typeof(TContext).Name);
            }
            else
            {
                logger.LogError("null context was supplied. {Name}", typeof(TContext).Name);
            }
        }
        catch (Exception e)
        {
            logger.LogError("Db Migration Failed: {Name} , {E}", typeof(TContext).Name, e.ToString());
        }

        return host;
    }
}