using shared;
using telegram_bor_models.models;

namespace telegram_services.Services;

public interface IFriendMessageServiceHandler : IMessageServiceHandler<FriendRequestMessage> { }