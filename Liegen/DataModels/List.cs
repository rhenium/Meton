using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class List : IRawApiResponse
    {
        [JsonProperty("member_count")]
        public int MemberCount { get; protected set; }
        [JsonProperty("uri")]
        public string Uri { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("full_name")]
        public string FullName { get; protected set; }
        [JsonProperty("subscriber_count")]
        public int SubscriberCount { get; protected set; }
        [JsonProperty("description")]
        public string Description { get; protected set; }
        [JsonProperty("mode")]
        public string Mode { get; protected set; }
        [JsonProperty("slug")]
        public string Slug { get; protected set; }
        [JsonProperty("user")]
        public User User { get; protected set; }
        [JsonProperty("id")]
        public string Id { get; protected set; }
        [JsonProperty("id_str")]
        public string IdStr { get; protected set; }

        [JsonProperty("created_at")]
        protected string CreatedAtString { get; set; }
        public DateTime CreatedAt { get; protected set; }

        public List Fix()
        {
            this.CreatedAt = this.CreatedAtString.ParseDateTime();
            this.User.Fix();
            return this;
        }
    }
}
