using System.Reflection;
using Chat.Core.IRepository;
using Chat.Infrastructure.Data;
using Chat.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure.Extension;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ChatDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        serviceCollection.AddScoped<IGroupRepository, GroupRepository>();
        serviceCollection.AddScoped<IMessageRepository, MessageRepository>();
        serviceCollection.AddScoped<IConversationRepository, ConversationRepository>();
        serviceCollection.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
        
        return serviceCollection;
    }
}