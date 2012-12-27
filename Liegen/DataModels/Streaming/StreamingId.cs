using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingId
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
    }
}
