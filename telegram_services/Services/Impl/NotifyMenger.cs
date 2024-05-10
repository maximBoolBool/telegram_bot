using telegram_services.Configs;
using Telegram.Bot;

namespace telegram_services.Services.Impl;

public class NotifyMenger : INotifyMeneger
{
    #region Fields
    
    private readonly TelegramBotClient _botClient;

    #endregion
    
    #region .ctor
    
    public NotifyMenger(TelegramBotConfigs configs)
    {
        _botClient = new TelegramBotClient(configs.TelegramBotToken);
    }

    #endregion

    #region Public Methodes

    public async Task SendAsync(
        string userTelegramId,
        string message,
        CancellationToken cancellationToken = default)
    {
        await _botClient.SendTextMessageAsync(userTelegramId, message, cancellationToken: cancellationToken);
    }

    #endregion
}