using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meton.Liegen.Utility;

namespace Meton.Liegen.DataModels
{
    public class StatusBase : ApiResponseBase
    {
        [JsonProperty("annotations")]
        public object Annotations { get; set; }
        [JsonProperty("created_at")]
        public string StringCreatedAt { get; set; }
        [JsonProperty("entities")]
        public Entities Entities { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("id_str")]
        public string IdStr { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("truncated")]
        public bool? Truncated { get; set; }
        
        public DateTime CreatedAt { get; set; }

        protected StatusBase Fix()
        {
            this.CreatedAt = this.StringCreatedAt.ParseDateTime();
            return this;
        }
    }
}
