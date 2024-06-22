using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Core.IRepository;
using Notification.Infrastructure.Data;
using Notification.Infrastructure.Repository;

namespace Notification.Infrastructure.Extensions;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<NotificationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
        serviceCollection.AddScoped<IOrderTokenRepository, OrderTokenRepository>();

        return serviceCollection;
    }
}