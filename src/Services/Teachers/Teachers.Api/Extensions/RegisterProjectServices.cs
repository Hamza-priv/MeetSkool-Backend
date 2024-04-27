using Teachers.Application.Extensions;
using Teachers.Infrastructure.Extension;

namespace Teachers.Api.Extensions;

public static class RegisterProjectServices
{
    public static IServiceCollection AddProjectServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddInfrastructureServices(configuration);
        serviceCollection.AddApplicationServices();
        return serviceCollection;
    }
}