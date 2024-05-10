using Newtonsoft.Json;

namespace telegram_bor_models.models;

public class FriendRequestMessage
{
    [JsonProperty("user_id")]
    public long UserId { get; set; }
    
    [JsonProperty("request_login")]
    public string RequestLogin { get; set; }
}