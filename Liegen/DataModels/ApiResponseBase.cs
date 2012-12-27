using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class ApiResponseBase
    {
        [JsonProperty("errors")]
        public ErrorMessage[] ErrorMessages { get; set; }
    }
}
