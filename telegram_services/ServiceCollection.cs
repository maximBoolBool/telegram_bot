using Microsoft.Extensions.DependencyInjection;
using telegram_services.RabbitServicesImpl;
using telegram_services.RabbitServicesImpl.Impl;
using telegram_services.Services;
using telegram_services.Services.BackGroundServices;
using telegram_services.Services.Impl;

namespace telegram_services;

public static class ServiceCollection
{
    public static void AddTelegramServices(this IServiceCollection services)
    {
        services.AddScoped<INotifyMeneger, NotifyMenger>();
        services.AddSingleton<IFriendMessageServiceHandler, FriendMessageServiceHandler>();
        services.AddSingleton<IFriendConsumer, FriendConsumer>();

        services.AddSingleton<INotifyMessageServiceHandler, NotifyMessageServiceHandler>();
        services.AddSingleton<INotifyConsumer, NotifyConsumer>();

        services.AddHostedService<FriendRequestMessageBackgroundService>();
        services.AddHostedService<NotifyMessageBackgroudService>();
    }
}