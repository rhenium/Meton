using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class StatusActivitySummary : ApiResponseBase
    {
        [JsonProperty("favoriters_count")]
        public string FavoritersCountString { get; set; }
        [JsonProperty("retweeters_count")]
        public string RetweetersCountString { get; set; }
        [JsonProperty("repliers_count")]
        public string RepliersCountString { get; set; }
        [JsonProperty("favoriters")]
        public long[] Favoriters { get; set; }
        [JsonProperty("retweeters")]
        public long[] Retweeters { get; set; }
        [JsonProperty("repliers")]
        public long[] Repliers { get; set; }

        public int FavoritersCount { get; set; }
        public int RetweetersCount { get; set; }
        public int RepliersCount { get; set; }

        public StatusActivitySummary Fix()
        {
            FavoritersCount = int.Parse(FavoritersCountString);
            RetweetersCount = int.Parse(RetweetersCountString);
            RepliersCount = int.Parse(RepliersCountString);

            return this;
        }
    }
}
