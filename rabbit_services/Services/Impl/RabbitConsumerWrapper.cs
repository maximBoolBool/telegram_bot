using System.Text;
using Newtonsoft.Json;
using rabbit_services.Configs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using shared;

namespace rabbit_services.Services.Impl;

public class RabbitConsumerWrapper<TMessage> : IRabbitConsumerWrapper<TMessage>, IDisposable
    where TMessage : class
{
    #region Fields
    
    private readonly AsyncEventingBasicConsumer _consumer;
    private readonly IRabbitConsumerConfigs _options;
    private readonly IConnection _connection;
    private readonly IModel _chanel;
    private readonly IMessageServiceHandler<TMessage> _messageServiceHandler;
    
    #endregion

    #region .ctor

    public RabbitConsumerWrapper(
        IRabbitConsumerConfigs options,
        IMessageServiceHandler<TMessage> messageServiceHandler)
    {
        _options = options;
        
        var factory = new ConnectionFactory { HostName = _options.Host };
        _connection = factory.CreateConnection();
        _chanel = _connection.CreateModel();

        _consumer = new AsyncEventingBasicConsumer(_chanel);
        _messageServiceHandler = messageServiceHandler;
    }

    #endregion

    #region Public Methodes

    public void StartConsume()
    {
        _consumer.Received += ConsumeAsync;
        _chanel.BasicConsume(_options.Queue, false, _consumer);
    }

    public void StopConsume()
    {
        _consumer.Received -= ConsumeAsync;
    }

    #endregion

    #region Private Methodes

    private async Task ConsumeAsync(object? ob, BasicDeliverEventArgs args)
    {
        var body = Encoding.UTF8.GetString(args.Body.ToArray());
        var message = JsonConvert.DeserializeObject<TMessage>(body);
        await _messageServiceHandler.ConsumeAsync(message);
        
        _chanel.BasicAck(args.DeliveryTag, false);
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _connection.Dispose();
        _chanel.Dispose();
    }

    #endregion
}