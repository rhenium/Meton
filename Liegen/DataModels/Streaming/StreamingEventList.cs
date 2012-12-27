using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingEventList : StreamingEvent
    {
        [JsonProperty("target_object")]
        public List TargetObject { get; set; }

        public new StreamingElement ToStreamingElement()
        {
            var m = base.ToStreamingElement();
            m.EventTargetList = TargetObject;
            return m;
        }
    }
}
