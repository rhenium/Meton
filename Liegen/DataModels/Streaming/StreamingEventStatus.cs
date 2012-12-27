using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingEventStatus : StreamingEvent
    {
        [JsonProperty("target_object")]
        public Status TargetObject { get; set; }

        public new StreamingElement ToStreamingElement()
        {
            var m = base.ToStreamingElement();
            m.EventTargetStatus = TargetObject;
            return m;
        }
    }
}
