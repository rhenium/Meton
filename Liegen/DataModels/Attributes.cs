using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class Attributes
    {
        [JsonProperty("screet_address")]
        public string StreetAddress { get; set; }
        [JsonProperty("locality")]
        public string Locality { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("iso3")]
        public string Iso3 { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("app:id")]
        public string AppId { get; set; }
    }
}
