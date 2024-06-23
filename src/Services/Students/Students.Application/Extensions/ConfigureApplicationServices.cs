using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Students.Application.Services.Implementation;
using Students.Application.Services.Interfaces;

namespace Students.Application.Extensions;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStudentServices, StudentServices>();
        serviceCollection.AddScoped<IEducationServices, EducationServices>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddScoped<IFriendServices, FriendServices>();
        serviceCollection.AddScoped<ISubjectServices, SubjectServices>();
        serviceCollection.AddScoped<IStudentSubjectServices, StudentSubjectServices>();
        serviceCollection.AddScoped<IOrderServices, OrderServices>();

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