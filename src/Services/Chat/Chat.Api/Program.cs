using System.Reflection;
using Chat.Api;
using Chat.Api.Extensions;
using Chat.Application.Services.Implementation;
using Chat.Infrastructure.Consumer;
using Chat.Infrastructure.Data;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddProjectServices(configuration);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    var assembly = Assembly.GetExecutingAssembly();
    busConfigurator.AddConsumers(assembly);
    busConfigurator.AddSagas(assembly);
    busConfigurator.AddActivities(assembly);
    busConfigurator.AddSagaStateMachines(assembly);

    busConfigurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });

    busConfigurator.SetInMemorySagaRepositoryProvider();
});

builder.Services.AddLogging(configure => configure.AddConsole());


var app = builder.Build();
app.MigrateDatabase<ChatDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<ChatDbContextSeed>>();
    if (logger is not null)
    {
        ChatDbContextSeed.SeedAsync(context, logger).Wait();
    }
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHub<ChatServices>("chat");
app.UseAuthorization();

app.MapControllers();
app.Run();