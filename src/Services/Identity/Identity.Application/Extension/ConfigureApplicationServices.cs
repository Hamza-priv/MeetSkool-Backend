using System.Reflection;
using Identity.Application.AccountServices;
using Identity.Application.Services.Implementation;
using Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application.Extension;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAccountServices, Services.Implementation.AccountServices>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddScoped<ApplicationServices>();
        return serviceCollection;
    }
}