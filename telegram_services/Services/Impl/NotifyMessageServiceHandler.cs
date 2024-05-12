using bot_entities.Factory;
using telegram_bor_models.models;
using telegram_services.Configs;
using Telegram.Bot;

namespace telegram_services.Services.Impl;

public class NotifyMessageServiceHandler : INotifyMessageServiceHandler
{
    #region Fields

    private readonly ITelegramDbFactory _dbFactory;
    private readonly TelegramBotClient _botClient;

    #endregion

    #region .ctor

    public NotifyMessageServiceHandler(ITelegramDbFactory dbFactory, TelegramBotConfigs botConfigs)
    {
        _dbFactory = dbFactory;
        _botClient = new TelegramBotClient(botConfigs.TelegramBotToken);
    }

    #endregion
    
    #region Public Message
    
    public async Task ConsumeAsync(NotifyMessage message)
    {
        using var db = _dbFactory.CreateScope();

        var query = db.Users.CreateQuery();
        var entities = query.Where( e => message.UserIds.Contains(e.UserId))
            .ToArray();

        var messagesTasks = entities.Select(e => SendNotifyAsync(e.UserTelegramID, message.UserName));
        await Task.WhenAll(messagesTasks.ToArray());
    }

    #endregion

    #region Fieldes

    private async Task SendNotifyAsync(string telegramChatId, string userLogin) => 
        await _botClient.SendTextMessageAsync(telegramChatId, $"Ваш друг {userLogin} указал новое желание!!!");

    #endregion
    
}