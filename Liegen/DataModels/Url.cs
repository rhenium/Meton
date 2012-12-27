using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class Url : ApiResponseBase
    {
        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }
        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }
        [JsonProperty("indices")]
        public int[] Indices { get; set; }
        [JsonProperty("url")]
        public string Uri { get; set; }
    }
}
