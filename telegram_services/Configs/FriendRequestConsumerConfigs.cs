﻿using rabbit_services.Configs;

namespace telegram_services.Configs;

public class FriendRequestConsumerConfigs : IRabbitConsumerConfigs
{
    public string Host { get; set; }
    
    public string Queue { get; set; }

    public int Port { get; set; }
}