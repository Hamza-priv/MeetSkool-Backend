using Chat.Application.Extension;

namespace Chat.Api.Extensions;

public static class RegisterProjectServices
{
    public static IServiceCollection AddProjectServices( this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddApplicationServices();
        return serviceCollection;
    }
}