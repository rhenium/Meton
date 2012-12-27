using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class List
    {
        [JsonProperty("created_at")]
        public string StringCreatedAt { get; set; }
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("subscriber_count")]
        public int SubscriberCount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        public DateTime CreatedAt { get; set; }

        public List Fix()
        {
            this.CreatedAt = this.StringCreatedAt.ParseDateTime();
            this.User.Fix();
            return this;
        }
    }
}
