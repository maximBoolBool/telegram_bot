namespace bot_entities.Repositories;

/// <summary>
///     DbWorker для бота в тг
/// </summary>
public interface ITelegramDbWorker : IDisposable
{
    /// <summary>
    ///     Пользователи
    /// </summary>
    IUserRepository Users { get; set; }
}