using System.Reflection;
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
        return serviceCollection;
    }
}