using System;

namespace Meton.Liegen.DataModels.Streaming
{
    public class StreamingElement
    {
        public StreamingEventKind EventKind { get; set; }
        public User EventSourceUser { get; set; }
        public User EventTargetUser { get; set; }
        public Status EventTargetStatus { get; set; }
        public List EventTargetList { get; set; }
        public DateTime EventCreatedAt { get; set; }

        public DirectMessage DirectMessage { get; set; }
        public Status Status { get; set; }

        public long DeletedId { get; set; }

        public long[] FriendsIds { get; set; }
    }
}
