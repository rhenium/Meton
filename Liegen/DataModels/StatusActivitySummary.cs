using Newtonsoft.Json;

namespace Meton.Liegen.DataModels
{
    public class StatusActivitySummary : ApiResponseBase
    {
        [JsonProperty("favoriters_count")]
        protected string FavoritersCountString { get; set; }
        [JsonProperty("retweeters_count")]
        protected string RetweetersCountString { get; set; }
        [JsonProperty("repliers_count")]
        protected string RepliersCountString { get; set; }
        [JsonProperty("favoriters")]
        public long[] Favoriters { get; protected set; }
        [JsonProperty("retweeters")]
        public long[] Retweeters { get; protected set; }
        [JsonProperty("repliers")]
        public long[] Repliers { get; protected set; }

        public int FavoritersCount { get; protected set; }
        public int RetweetersCount { get; protected set; }
        public int RepliersCount { get; protected set; }

        public StatusActivitySummary Fix()
        {
            FavoritersCount = int.Parse(FavoritersCountString);
            RetweetersCount = int.Parse(RetweetersCountString);
            RepliersCount = int.Parse(RepliersCountString);

            return this;
        }
    }
}
