using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;
using Teachers.Infrastructure.Repository;

namespace Teachers.Infrastructure.Extension;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TeacherDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        serviceCollection.AddScoped<ITeacherRepository, TeacherRepository>();
        serviceCollection.AddScoped<IEducationRepository, EducationRepository>();
        serviceCollection.AddScoped<ISubjectRepository, SubjectRepository>();
        serviceCollection.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
        serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        return serviceCollection;
    }
}