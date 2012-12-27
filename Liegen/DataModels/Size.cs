using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class Size
    {
        [JsonProperty("h")]
        public int H { get; set; }
        [JsonProperty("resize")]
        public string Resize { get; set; }
        [JsonProperty("w")]
        public int W { get; set; }
    }
}
