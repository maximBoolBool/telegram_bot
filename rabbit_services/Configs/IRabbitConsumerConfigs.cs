namespace rabbit_services.Configs;

public interface IRabbitConsumerConfigs
{
    public string Host { get; set; }
    
    public string Queue { get; set; }
    
    public int Port { get; set; }
}