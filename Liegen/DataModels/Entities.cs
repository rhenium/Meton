using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class Entities
    {
        [JsonProperty("hashtags")]
        public Hashtags[] Hashtags { get; set; }
        [JsonProperty("media")]
        public Media[] Media { get; set; }
        [JsonProperty("urls")]
        public Url[] Urls { get; set; }
        [JsonProperty("user_mentions")]
        public UserMentions[] UserMentions { get; set; }
    }
}
