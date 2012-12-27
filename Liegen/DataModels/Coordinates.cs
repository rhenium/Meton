using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class Coordinates
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public double[] CoordinatesData { get; set; }
    }
}
