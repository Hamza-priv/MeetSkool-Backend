using Identity.Application.Extension;
using Identity.Infrastructure.Extension;

namespace Identity.Api.Extensions;

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