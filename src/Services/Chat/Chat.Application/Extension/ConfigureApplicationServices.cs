﻿using System.Reflection;
using Chat.Application.Services.Implementation;
using Chat.Application.Services.Interface;
using Chat.Core.Models;
using Chat.Infrastructure.Consumer;
using Contracts;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application.Extension;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGroupServices, GroupServices>();
        serviceCollection.AddScoped<IMessageServices, MessageServices>();
        serviceCollection.AddScoped<IPublisherServices, PublisherServices>();
        serviceCollection.AddScoped<IConversationServices, ConversationServices>();
        serviceCollection.AddScoped<IMessageServices, MessageServices>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddSignalR();
        return serviceCollection;
    }
}