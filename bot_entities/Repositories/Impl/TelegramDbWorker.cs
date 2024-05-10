namespace bot_entities.Repositories.Impl;

/// <inheritdoc cref="ITelegramDbWorker"/>
public class TelegramDbWorker : ITelegramDbWorker
{
    #region Repositories

    /// <inheritdoc cref="ITelegramDbWorker"/>
    public IUserRepository Users { get; set; }

    #endregion

    #region .ctor

    /// <inheritdoc cref=".ctor"/>
    public TelegramDbWorker(BotTelegramContext context)
    {
        Users = new UserRepository(context);
    }

    #endregion

    #region Disposeble

    public void Dispose()
    {
    }

    #endregion
}