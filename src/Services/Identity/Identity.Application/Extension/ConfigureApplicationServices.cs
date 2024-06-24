using System.Reflection;
using Identity.Application.AccountServices;
using Identity.Application.Services.Implementation;
using Identity.Application.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application.Extension;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAccountServices, Services.Implementation.AccountServices>();
        serviceCollection.AddScoped<IEmailServices, EmailServices>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddScoped<ApplicationServices>();
        
        var assembly = Assembly.GetExecutingAssembly();
        serviceCollection.AddMassTransit(conf =>
        {
            conf.SetKebabCaseEndpointNameFormatter();
            conf.SetInMemorySagaRepositoryProvider();
            conf.AddConsumers(assembly);
            conf.AddSagaStateMachines(assembly);
            conf.AddSagas(assembly);
            conf.AddActivities(assembly);
            
            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost","/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        });
        return serviceCollection;
    }
}