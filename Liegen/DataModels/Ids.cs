using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meton.Liegen.DataModels
{
    public class IdsResponse : ApiResponseBase
    {
        [JsonProperty("ids")]
        public long[] Ids { get; protected set; }
        [JsonProperty("previous_cursor")]
        public long PreviousCursor { get; protected set; }
        [JsonProperty("next_cursor")]
        public long NextCursor { get; protected set; }
    }
}
