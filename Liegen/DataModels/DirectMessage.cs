using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels
{
    public class DirectMessage : StatusBase
    {
        [JsonProperty("recipient")]
        public User Recipient { get; protected set; }
        [JsonProperty("recipient_id")]
        public long RecipientId { get; protected set; }
        [JsonProperty("recipient_screen_name")]
        public string RecipientScreenName { get; protected set; }
        [JsonProperty("sender")]
        public User Sender { get; protected set; }
        [JsonProperty("sender_id")]
        public long SenderId { get; protected set; }
        [JsonProperty("sender_screen_name")]
        public string SenderScreenName { get; protected set; }

        public new DirectMessage Fix()
        {
            base.Fix();
            return this;
        }
    }
}
