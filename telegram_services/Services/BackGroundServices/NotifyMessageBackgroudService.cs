using Microsoft.Extensions.Hosting;
using telegram_bor_models.models;
using telegram_services.RabbitServicesImpl;

namespace telegram_services.Services.BackGroundServices;

public class NotifyMessageBackgroudService : BackgroundService
{
    #region Fieldes

    private readonly INotifyConsumer _consumer;

    #endregion

    #region .ctor

    public NotifyMessageBackgroudService(INotifyConsumer consumer)
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