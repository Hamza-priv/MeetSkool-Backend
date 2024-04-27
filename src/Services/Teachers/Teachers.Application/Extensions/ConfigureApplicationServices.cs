using System.Reflection;
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
        return serviceCollection;
    }
}