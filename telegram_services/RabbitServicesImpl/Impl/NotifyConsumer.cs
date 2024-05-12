using rabbit_services.Configs;
using rabbit_services.Services.Impl;
using shared;
using telegram_bor_models.models;
using telegram_services.Configs;
using telegram_services.Services;

namespace telegram_services.RabbitServicesImpl.Impl;

public class NotifyConsumer : RabbitConsumerWrapper<NotifyMessage>, INotifyConsumer
{
    public NotifyConsumer(
        NotifyMessageConsumerConfigs options,
        INotifyMessageServiceHandler messageServiceHandler)
        : base(options, messageServiceHandler) { }
}