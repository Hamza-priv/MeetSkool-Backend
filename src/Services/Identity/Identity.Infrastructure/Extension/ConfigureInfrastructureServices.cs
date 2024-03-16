using Identity.Core.Entities;
using Identity.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
namespace Identity.Infrastructure.Extension;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityDbConnection")));
        
        
        serviceCollection.AddIdentity<MeetSkoolIdentityUser, MeetSkoolIdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();
        serviceCollection.AddScoped<IIdentityDbContext, IdentityDbContext>();
        var identityBuilder = serviceCollection.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
                options.IssuerUri = configuration.GetValue<string>("IdentityUrl");
            })
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            //.AddInMemoryClients(Config.GetClients(services, this.Configuration))
            .AddAspNetIdentity<MeetSkoolIdentityUser>()
            .AddProfileService<ProfileService>();
        
       // not recommended for production - you need to store your key material somewhere secure
        
        identityBuilder.AddDeveloperSigningCredential();
        
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer("Bearer", options =>
        {
            options.Authority = configuration.GetValue<string>("IdentityUrl");
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateLifetime = true,
            };
        });
        
        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "MeetSkool");
            });
        });
        
        
        return serviceCollection;
    }
}