using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class User : ApiResponseBase
    {
        [JsonProperty("contributors_enabled")]
        public bool? ContributorsEnabled { get; set; }
        [JsonProperty("created_at")]
        public string StringCreatedAt { get; set; }
        [JsonProperty("default_profile")]
        public bool? DefaultProfile { get; set; }
        [JsonProperty("default_profile_image")]
        public bool? DefaultProfileImage { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }
        [JsonProperty("follow_request_sent")]
        public string FollowRequestSent { get; set; }
        [JsonProperty("following")]
        [Obsolete]
        public string Following { get; set; }
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }
        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }
        [JsonProperty("geo_enabled")]
        public bool GeoEnabled { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
        [JsonProperty("is_translator")]
        public bool IsTranslator { get; set; }
        [JsonProperty("lang")]
        public string Lang { get; set; }
        [JsonProperty("listed_count")]
        public int ListedCount { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("notifications")]
        [Obsolete]
        public bool? Notifications { get; set; }
        [JsonProperty("profile_background_color")]
        public string ProfileBackgroundColor { get; set; }
        [JsonProperty("profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; set; }
        [JsonProperty("profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlHttps { get; set; }
        [JsonProperty("profile_background_tile")]
        public bool ProfileBackgroundTile { get; set; }
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [JsonProperty("profile_image_url_https")]
        public string ProfileImageUrlHttps { get; set; }
        [JsonProperty("profile_link_color")]
        public string ProfileLinkColor { get; set; }
        [JsonProperty("profile_sidebar_border_color")]
        public string ProfileSidebarBorderColor { get; set; }
        [JsonProperty("profile_sidebar_fill_color")]
        public string ProfileSidebarFillColor { get; set; }
        [JsonProperty("profile_text_color")]
        public string ProfileTextColor { get; set; }
        [JsonProperty("profile_use_background_image")]
        public bool ProfileUseBackgroundImage { get; set; }
        [JsonProperty("protected")]
        public bool Protected { get; set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
        [JsonProperty("show_all_inline_media")]
        public bool ShowAllInlineMedia { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("utc_offset")]
        public int? UtcOffset { get; set; }
        [JsonProperty("verified")]
        public bool Verified { get; set; }
        [JsonProperty("withheld_countries")]
        public string WithheldCountries { get; set; }
        [JsonProperty("withheld_scope")]
        public string WithheldScope { get; set; }

        public DateTime CreatedAt { get; set; }

        public User Fix()
        {
            this.CreatedAt = this.StringCreatedAt.ParseDateTime();
            return this;
        }
    }
}
