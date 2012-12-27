using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingFriends
    {
        [JsonProperty("friends")]
        public long[] Friends { get; set; }
    }
}
