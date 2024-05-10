namespace shared;

public interface IMessageServiceHandler<TMessage> where TMessage : class
{
    Task ConsumeAsync(TMessage message);
}