using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Entity
{
    public class Media
    {
        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }
        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
        [JsonProperty("indices")]
        public int[] Indices { get; set; }
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
        [JsonProperty("media_url_https")]
        public string MediaUrlHttps { get; set; }
        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }
        [JsonProperty("source_status_id")]
        public long? SourceStatusId { get; set; }
        [JsonProperty("source_status_id_str")]
        public string SourceStatusIdStr { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("url")]
        public string Uri { get; set; }
    }
}
