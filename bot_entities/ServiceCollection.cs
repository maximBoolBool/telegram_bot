using bot_entities.Repositories;
using bot_entities.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bot_entities;

public static class ServiceCollection
{
    public static void AddUserEntities(this IServiceCollection services)
    {
        services.AddDbContext<BotTelegramContext>(options => options.UseNpgsql());
        services.AddSingleton<ITelegramDbWorker, TelegramDbWorker>();
    }
}