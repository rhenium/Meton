using Newtonsoft.Json;

namespace Meton.Liegen.DataModels.Entity
{
    public class Sizes
    {
        [JsonProperty("thumb")]
        public Size Thumb { get; set; }
        [JsonProperty("large")]
        public Size Large { get; set; }
        [JsonProperty("medium")]
        public Size Medium { get; set; }
        [JsonProperty("small")]
        public Size Small { get; set; }
    }
}
