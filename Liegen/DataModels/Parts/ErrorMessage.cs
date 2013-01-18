using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Parts
{
    public class ErrorMessage
    {
        [JsonProperty("message")]
        public string Message { get; protected set; }
        [JsonProperty("code")]
        public int Code { get; protected set; }
    }
}
