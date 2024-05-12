using telegram_services.Configs;

namespace telegram_bot;

public static class ConfigureExtension
{
    public static void AddEnviromentVariables(this IServiceCollection services, IConfiguration configuration)
    {
        DotNetEnv.Env.Load();

        var botConfigs = new TelegramBotConfigs
        {
            TelegramBotToken = configuration[ConfigurationVaribalesKeys.TelegramBotToken]
        };

        var friendRequestConfigs = new FriendRequestConsumerConfigs
        {
            Queue = configuration[ConfigurationVaribalesKeys.FriendRequestQueue],
            Host = configuration[ConfigurationVaribalesKeys.RabbitHost],
            Port = int.Parse(configuration[ConfigurationVaribalesKeys.RabbitPort])
        };

        var notifyConfigs = new NotifyMessageConsumerConfigs
        {
            Queue = configuration[ConfigurationVaribalesKeys.NotifyQueue],
            Host = configuration[ConfigurationVaribalesKeys.RabbitHost],
            Port = int.Parse(configuration[ConfigurationVaribalesKeys.RabbitPort])
        };

        services.AddSingleton(notifyConfigs);
        services.AddSingleton(botConfigs);
        services.AddSingleton(friendRequestConfigs);
    }
}