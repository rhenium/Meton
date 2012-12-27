using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class ErrorMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
