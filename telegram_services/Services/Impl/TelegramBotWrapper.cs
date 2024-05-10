using System.ComponentModel;
using telegram_services.Configs;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace telegram_services.Services.Impl;

public class TelegramBotWrapper : ITelegramBotWrapper
{
    #region Fields

    private readonly TelegramBotConfigs _configs;
    private readonly TelegramBotClient _botClient;
    private readonly ReceiverOptions _receiverOptions;

    private const string AuthCommand = "/auth";
    private const string SettingsCommand = "/settings";
    private const string HelpCommand = "/help";

    #endregion

    #region .ctor

    public TelegramBotWrapper(TelegramBotConfigs configs)
    {
        _configs = configs;
        _botClient = new TelegramBotClient(_configs.TelegramBotToken);
        _receiverOptions = new ReceiverOptions();
    }

    #endregion

    #region Public Methodes

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cancellationToken);
    }

    #endregion

    #region Private Methodes

    private static async Task UpdateHandler(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {
        switch (update.Message?.Text)
        {
            case AuthCommand :
                break;
            
            case SettingsCommand :
                break;
            
            case HelpCommand : 
                break;
            
            default:
                await botClient.SendTextMessageAsync(
                    update.Id,
                    "Прошупрощения такой команды нет(",
                    cancellationToken: cancellationToken);
                break;
        }
    }
    
    private static Task ErrorHandler(
        ITelegramBotClient botClient,
        Exception error,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    #endregion
    
}