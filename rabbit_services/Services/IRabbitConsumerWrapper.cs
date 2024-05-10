namespace rabbit_services.Services;

public interface IRabbitConsumerWrapper<TMessage>
    where TMessage : class
{
    void StartConsume();

    void StopConsume();
}