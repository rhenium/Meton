using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;

namespace Meton.Liegen.DataModels.Streaming
{
    internal class StreamingEvent
    {
        [JsonProperty("event")]
        public string StringEventKind { get; set; }
        //[JsonProperty("target")]
        //public User EventTargetUser { get; set; }
        //[JsonProperty("source")]
        //public User EventSourceUser { get; set; }
        [JsonProperty("created_at")]
        public string StringCreatedAt { get; set; }

        public StreamingEventKind EventKind { get; set; }
        public DateTime CreatedAt { get; set; }

        public StreamingEvent Fix()
        {
            switch (this.StringEventKind)
            {
                case "block":
                    this.EventKind = StreamingEventKind.Block;
                    break;
                case "unblock":
                    this.EventKind = StreamingEventKind.Unblock;
                    break;
                case "favorite":
                    this.EventKind = StreamingEventKind.Favorite;
                    break;
                case "unfavorite":
                    this.EventKind = StreamingEventKind.Unfavorite;
                    break;
                case "follow":
                    this.EventKind = StreamingEventKind.Follow;
                    break;
                case "unfollow":
                    this.EventKind = StreamingEventKind.Unfollow;
                    break;
                case "list_created":
                    this.EventKind = StreamingEventKind.ListCreated;
                    break;
                case "list_destroyed":
                    this.EventKind = StreamingEventKind.ListDestroyed;
                    break;
                case "list_updated":
                    this.EventKind = StreamingEventKind.ListUpdated;
                    break;
                case "list_member_added":
                    this.EventKind = StreamingEventKind.ListMemberAdded;
                    break;
                case "list_member_removed":
                    this.EventKind = StreamingEventKind.ListMemberRemoved;
                    break;
                case "list_user_subscribed":
                    this.EventKind = StreamingEventKind.ListUserSubscribed;
                    break;
                case "list_user_unsubscribed":
                    this.EventKind = StreamingEventKind.ListUserUnsubscribed;
                    break;
                case "user_update":
                    this.EventKind = StreamingEventKind.UserUpdate;
                    break;
                default:
                    this.EventKind = StreamingEventKind.Undefined;
                    break;
            }

            if (this.StringCreatedAt != null)
            {
                this.CreatedAt = this.StringCreatedAt.ParseDateTime();
            }

            return this;
        }

        public StreamingElement ToStreamingElement()
        {
            return new StreamingElement()
            {
                EventKind = this.EventKind,
                //EventTargetUser = this.EventTargetUser,
                //EventSourceUser = this.EventSourceUser,
                EventCreatedAt = this.CreatedAt
            };
        }
    }
}
