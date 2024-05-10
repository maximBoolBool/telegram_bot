using bot_entities.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace bot_entities.Factory;

/// <inheritdoc cref="ITelegramDbFactory"/>
public class TelegramDbFactory : ITelegramDbFactory
{
    #region Fields

    private readonly IServiceScopeFactory _factory;

    #endregion

    #region .ctor

    /// .ctor
    public TelegramDbFactory(IServiceScopeFactory factory)
    {
        _factory = factory;
    }

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public ITelegramDbWorker CreateScope()
    {
        var scope = _factory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<ITelegramDbWorker>();
    }

    #endregion
}