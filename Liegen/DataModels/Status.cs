using Meton.Liegen.DataModels.Parts;
using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class Status : StatusBase
    {
        [JsonProperty("contributors")]
        public Contributors[] Contributors { get; protected set; }
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; protected set; }
        [JsonProperty("current_user_retweet")]
        public object CurrentUserRetweet { get; protected set; }
        [JsonProperty("favorited")]
        public bool? Favorited { get; protected set; }
        [JsonProperty("geo")]
        [Obsolete]
        public object Geo { get; protected set; }
        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; protected set; }
        [JsonProperty("in_reply_to_status_id")]
        public long? InReplyToStatusId { get; protected set; }
        [JsonProperty("in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr { get; protected set; }
        [JsonProperty("in_reply_to_user_id")]
        public long? InReplyToUserId { get; protected set; }
        [JsonProperty("in_reply_to_user_id_str")]
        public string InReplyToUserIdStr { get; protected set; }
        [JsonProperty("place")]
        public Place Place { get; protected set; }
        [JsonProperty("possibly_sensitive")]
        public bool? PossiblySensitive { get; protected set; }
        [JsonProperty("scopes")]
        public object Scopes { get; protected set; } // promoted tweet
        [JsonProperty("retweet_count")]
        public int RetweetCount { get; protected set; }
        [JsonProperty("retweeted")]
        public bool Retweeted { get; protected set; }
        [JsonProperty("source")]
        public string Source { get; protected set; }
        [JsonProperty("user")]
        public User User { get; protected set; }
        [JsonProperty("withheld_copyright")]
        public bool? WithheldCopyright { get; protected set; }
        [JsonProperty("withheld_countries")]
        public string WithheldCountries { get; protected set; }
        [JsonProperty("withheld_scope")]
        public string WithheldScope { get; protected set; }

        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; protected set; }


        public new Status Fix()
        {
            base.Fix();
            return this;
        }
    }
}
