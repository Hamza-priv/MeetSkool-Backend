using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Services.Implementation;
using Notification.Application.Services.Interfaces;

namespace Notification.Application.Extension;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPublish, Publisher>();
        serviceCollection.AddScoped<ITokenServices, TokenServices>();
        serviceCollection.AddSignalR();

        serviceCollection.AddMassTransit(busConfigurator =>
        {
            /*
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            */
            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost","/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                /*
                cfg.ConfigureEndpoints(context);
            */
            });
        });
        return serviceCollection;
    }
}