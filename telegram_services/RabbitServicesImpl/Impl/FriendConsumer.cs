using rabbit_services.Configs;
using rabbit_services.Services.Impl;
using telegram_bor_models.models;
using telegram_services.Services;

namespace telegram_services.RabbitServicesImpl.Impl;

public class FriendConsumer : RabbitConsumerWrapper<FriendRequestMessage>, IFriendConsumer
{
    public FriendConsumer(
        IRabbitConsumerConfigs options,
        IFriendMessageServiceHandler messageServiceHandler) 
        : base(options, messageServiceHandler) { }
}