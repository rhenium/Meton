using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class Status : StatusBase
    {
        [JsonProperty("contributors")]
        public Contributors[] Contributors { get; set; }
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("current_user_retweet")]
        public object CurrentUserRetweet { get; set; }
        [JsonProperty("favorited")]
        public bool? Favorited { get; set; }
        [JsonProperty("geo")]
        [Obsolete]
        public object Geo { get; set; }
        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }
        [JsonProperty("in_reply_to_status_id")]
        public long? InReplyToStatusId { get; set; }
        [JsonProperty("in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr { get; set; }
        [JsonProperty("in_reply_to_user_id")]
        public long? InReplyToUserId { get; set; }
        [JsonProperty("in_reply_to_user_id_str")]
        public string InReplyToUserIdStr { get; set; }
        [JsonProperty("place")]
        public Place Place { get; set; }
        [JsonProperty("possibly_sensitive")]
        public bool? PossiblySensitive { get; set; }
        [JsonProperty("scopes")]
        public object Scopes { get; set; } // promoted tweet
        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }
        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("withheld_copyright")]
        public bool? WithheldCopyright { get; set; }
        [JsonProperty("withheld_countries")]
        public string WithheldCountries { get; set; }
        [JsonProperty("withheld_scope")]
        public string WithheldScope { get; set; }

        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; set; }

        
        public new Status Fix()
        {
            base.Fix();
            return this;
        }
    }
}
