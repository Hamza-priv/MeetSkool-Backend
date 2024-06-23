using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Teachers.Application.Services.Implementation;
using Teachers.Application.Services.Interfaces;

namespace Teachers.Application.Extensions;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITeacherServices, TeacherServices>();
        serviceCollection.AddScoped<IEducationServices, EducationServices>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddScoped<ISubjectServices, SubjectServices>();
        serviceCollection.AddScoped<ITeacherSubjectServices, TeacherSubjectServices>();
        serviceCollection.AddScoped<ICommentServices, CommentServices>();

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
                    cfg.Host("localhost", "/", h =>
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