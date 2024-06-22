using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Students.Core.IRepository;
using Students.Infrastructure.Data;
using Students.Infrastructure.Repository;

namespace Students.Infrastructure.Extension;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<StudentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
        serviceCollection.AddScoped<IEducationRepository, EducationRepository>();
        serviceCollection.AddScoped<IFriendRepository, FriendRepository>();
        serviceCollection.AddScoped<ISubjectRepository, SubjectRepository>();
        serviceCollection.AddScoped<IStudentSubjectsRepository, StudentSubjectRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        return serviceCollection;
    }
}