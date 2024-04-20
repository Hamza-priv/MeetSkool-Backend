using Students.Application.Extensions;
using Students.Infrastructure.Extension;

namespace Students.Api.Extensions;

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