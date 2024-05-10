using bot_entities.Repositories;

namespace bot_entities.Factory;

/// <summary>
///     Фабрика для <see cref="ITelegramDbWorker"/>
/// </summary>
public interface ITelegramDbFactory
{
    ITelegramDbWorker CreateScope();
}