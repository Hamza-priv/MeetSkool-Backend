using Notification.Application.Extension;
using Notification.Infrastructure.Extensions;

namespace Notification.Api.Extension;

public static class RegisterProjectServices
{
    public static IServiceCollection AddProjectServices( this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddInfrastructureServices(configuration);
        serviceCollection.AddApplicationServices();
        return serviceCollection;
    }
}