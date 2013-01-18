using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Entity
{
    public class UserMentions
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
        [JsonProperty("indices")]
        public int[] Indices { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
    }
}
