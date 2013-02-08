using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meton.Liegen.Utility;
using Meton.Liegen.DataModels.Entity;

namespace Meton.Liegen.DataModels
{
    public class StatusBase : IRawApiResponse
    {
        [JsonProperty("annotations")]
        public object Annotations { get; protected set; }
        [JsonProperty("entities")]
        public Entities Entities { get; protected set; }
        [JsonProperty("id")]
        public long Id { get; protected set; }
        [JsonProperty("id_str")]
        public string IdStr { get; protected set; }
        [JsonProperty("text")]
        public string Text { get; protected set; }
        [JsonProperty("truncated")]
        public bool? Truncated { get; protected set; }

        [JsonProperty("created_at")]
        protected string CreatedAtString { get; set; }
        public DateTime CreatedAt { get; protected set; }

        protected StatusBase Fix()
        {
            this.CreatedAt = this.CreatedAtString.ParseDateTime();
            return this;
        }
    }
}
