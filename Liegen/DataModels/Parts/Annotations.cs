using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Parts
{
    public class Annotations
    {
        [JsonProperty("ConversationRole")]
        public string ConversationRole { get; set; }
        [JsonProperty("FromUser")]
        public string FromUser { get; set; }
    }
}
