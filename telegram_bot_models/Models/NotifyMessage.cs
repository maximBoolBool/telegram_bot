using Newtonsoft.Json;

namespace telegram_bor_models.models;

public class NotifyMessage
{
    [JsonProperty("user_name")]
    public string UserName { get; set; }
    
    [JsonProperty("user_ids")]
    public long[] UserIds { get; set; }
}