using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class User : ApiResponseBase
    {
        [JsonProperty("contributors_enabled")]
        public bool? ContributorsEnabled { get; protected set; }
        [JsonProperty("default_profile")]
        public bool? DefaultProfile { get; protected set; }
        [JsonProperty("default_profile_image")]
        public bool? DefaultProfileImage { get; protected set; }
        [JsonProperty("description")]
        public string Description { get; protected set; }
        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; protected set; }
        [JsonProperty("follow_request_sent")]
        public string FollowRequestSent { get; protected set; }
        [JsonProperty("following")]
        [Obsolete]
        public string Following { get; protected set; }
        [JsonProperty("followers_count")]
        public int FollowersCount { get; protected set; }
        [JsonProperty("friends_count")]
        public int FriendsCount { get; protected set; }
        [JsonProperty("geo_enabled")]
        public bool GeoEnabled { get; protected set; }
        [JsonProperty("id")]
        public long Id { get; protected set; }
        [JsonProperty("id_str")]
        public string IdStr { get; protected set; }
        [JsonProperty("is_translator")]
        public bool IsTranslator { get; protected set; }
        [JsonProperty("lang")]
        public string Lang { get; protected set; }
        [JsonProperty("listed_count")]
        public int ListedCount { get; protected set; }
        [JsonProperty("location")]
        public string Location { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("notifications")]
        [Obsolete]
        public bool? Notifications { get; protected set; }
        [JsonProperty("profile_background_color")]
        public string ProfileBackgroundColor { get; protected set; }
        [JsonProperty("profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; protected set; }
        [JsonProperty("profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlHttps { get; protected set; }
        [JsonProperty("profile_background_tile")]
        public bool ProfileBackgroundTile { get; protected set; }
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; protected set; }
        [JsonProperty("profile_image_url_https")]
        public string ProfileImageUrlHttps { get; protected set; }
        [JsonProperty("profile_link_color")]
        public string ProfileLinkColor { get; protected set; }
        [JsonProperty("profile_sidebar_border_color")]
        public string ProfileSidebarBorderColor { get; protected set; }
        [JsonProperty("profile_sidebar_fill_color")]
        public string ProfileSidebarFillColor { get; protected set; }
        [JsonProperty("profile_text_color")]
        public string ProfileTextColor { get; protected set; }
        [JsonProperty("profile_use_background_image")]
        public bool ProfileUseBackgroundImage { get; protected set; }
        [JsonProperty("protected")]
        public bool Protected { get; protected set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; protected set; }
        [JsonProperty("show_all_inline_media")]
        public bool ShowAllInlineMedia { get; protected set; }
        [JsonProperty("status")]
        public Status Status { get; protected set; }
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; protected set; }
        [JsonProperty("time_zone")]
        public string TimeZone { get; protected set; }
        [JsonProperty("url")]
        public string Url { get; protected set; }
        [JsonProperty("utc_offset")]
        public int? UtcOffset { get; protected set; }
        [JsonProperty("verified")]
        public bool Verified { get; protected set; }
        [JsonProperty("withheld_countries")]
        public string WithheldCountries { get; protected set; }
        [JsonProperty("withheld_scope")]
        public string WithheldScope { get; protected set; }

        [JsonProperty("created_at")]
        protected string CreatedAtString { get; set; }
        public DateTime CreatedAt { get; protected set; }

        public User Fix()
        {
            this.CreatedAt = this.CreatedAtString.ParseDateTime();
            return this;
        }
    }
}
