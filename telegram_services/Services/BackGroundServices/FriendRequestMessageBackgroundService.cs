using Microsoft.Extensions.Hosting;
using telegram_services.RabbitServicesImpl;

namespace telegram_services.Services.BackGroundServices;

public class FriendRequestMessageBackgroundService : BackgroundService
{
    #region Fields

    private readonly IFriendConsumer _consumer;

    #endregion
    
    #region .ctor

    public FriendRequestMessageBackgroundService(IFriendConsumer consumer)
    {
        _consumer = consumer;
    }

    #endregion

    #region Ovverides

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        _consumer.StartConsume();
        
        return Task.CompletedTask;
    }    

    #endregion
}