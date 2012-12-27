using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingDelete
    {
        [JsonProperty("status")]
        public StreamingId Status { get; set; }
        [JsonProperty("direct_message")]
        public StreamingId DirectMessage { get; set; }

        public long Id { get; set; }

        public StreamingDelete Fix()
        {
            Id = (Status != null ? Status.Id : (DirectMessage != null ? DirectMessage.Id : 0));
            return this;
        }
    }
}
