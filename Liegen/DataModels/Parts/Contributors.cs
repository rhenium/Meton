using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Parts
{
    public class Contributors
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
    }
}
