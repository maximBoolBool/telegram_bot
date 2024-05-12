using bot_entities.Configuration;
using bot_entities.Factory;
using bot_entities.Repositories;
using bot_entities.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bot_entities;

public static class ServiceCollection
{
    public static void AddUserEntities(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[DbConfigurationKeys.DbConnectionKey];

        services.AddDbContext<BotTelegramContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<ITelegramDbWorker, TelegramDbWorker>();
        services.AddSingleton<ITelegramDbFactory, TelegramDbFactory>();
    }
}