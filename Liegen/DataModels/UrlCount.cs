using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class UrlCount : ApiResponseBase
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
