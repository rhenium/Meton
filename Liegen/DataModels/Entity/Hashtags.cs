using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Entity
{
    public class Hashtags
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
