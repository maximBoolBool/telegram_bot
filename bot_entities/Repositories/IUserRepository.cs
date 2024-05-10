using bot_entities.Entities;

namespace bot_entities.Repositories;

/// <summary>
///     Репозиторий для работы с <see cref="UserEntity"/>
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///    Получить пользователя по Id
    /// </summary>
    Task<UserEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить пользователя по Id Telegram
    /// </summary>
    Task<UserEntity?> GetByTelegramId(string telegramId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Создать нового пользователя
    /// </summary>
    Task CreateUser(UserEntity newUser, CancellationToken cancellationToken = default);
}