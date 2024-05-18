using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application.Extension;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection) 
    {
        serviceCollection.AddSignalR();
        return serviceCollection;
    }
}