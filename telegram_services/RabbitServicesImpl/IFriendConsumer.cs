using rabbit_services.Services;
using telegram_bor_models.models;

namespace telegram_services.RabbitServicesImpl;

public interface IFriendConsumer : IRabbitConsumerWrapper<FriendRequestMessage> { }