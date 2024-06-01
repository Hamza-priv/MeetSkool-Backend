using System.Reflection;
using Chat.Api;
using Chat.Api.Extensions;
using Chat.Application.Services.Implementation;
using Chat.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddProjectServices(configuration);

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