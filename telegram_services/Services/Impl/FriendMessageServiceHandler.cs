using bot_entities.Factory;
using Microsoft.Extensions.DependencyInjection;
using telegram_bor_models.models;

namespace telegram_services.Services.Impl;

public class FriendMessageServiceHandler : IFriendMessageServiceHandler
{
    #region Fields
    
    private readonly ITelegramDbFactory _dbFactory;
    private readonly INotifyMeneger _notifyMeneger;

    #endregion

    #region .ctor

    public FriendMessageServiceHandler(ITelegramDbFactory dbFactory, IServiceScopeFactory factory)
    {
        _dbFactory = dbFactory;
        using var scope = factory.CreateScope();
        _notifyMeneger = scope.ServiceProvider.GetRequiredService<INotifyMeneger>();
    }

    #endregion

    #region Public Methodes

    public async Task ConsumeAsync(FriendRequestMessage message)
    {
        using var db = _dbFactory.CreateScope();

        var userEntity = await db.Users.GetByIdAsync(message.UserId);
        if (userEntity == null)
        {
            return;
        }

        await _notifyMeneger.SendAsync(userEntity.UserTelegramID, "У вас новая заявка в друзья");
    }

    #endregion
}