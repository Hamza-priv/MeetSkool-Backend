using Chat.Application.Extension;
using Chat.Infrastructure.Extension;

namespace Chat.Api.Extensions;

public static class RegisterProjectServices
{
    public static IServiceCollection AddProjectServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddApplicationServices();
        serviceCollection.AddInfrastructureServices(configuration);
        return serviceCollection;
    }
}