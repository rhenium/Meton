using Meton.Liegen.DataModels.Streaming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Meton.Liegen.Utility;
using Meton.Liegen.DataModels;

namespace Meton.Liegen.Method.Streaming
{
    public static class StreamingCommon
    {
        internal static IObservable<StreamingElement> ParseStreamingResponseMessage(this IObservable<HttpResponseMessage> res)
        {
            return res
                .Select(p => new StreamReader(p.Content.ReadAsStreamAsync().Result))
                .TakeWhile(sr => !sr.EndOfStream)
                .Select(sr => sr.ReadLine())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s =>
                {
                    try
                    {
                        var desz = s.DeserializeJson<StreamingEvent>().Fix();
                        switch (desz.EventKind)
                        {
                            case StreamingEventKind.Undefined:
                                var friends = s.DeserializeJson<StreamingFriends>();
                                if (friends.Friends != null)
                                    return new StreamingElement()
                                    {
                                        EventKind = StreamingEventKind.Friends,
                                        FriendsIds = friends.Friends
                                    };
                                var tweet = s.DeserializeJson<Status>();
                                if (tweet.IdStr != null)
                                    return new StreamingElement()
                                    {
                                        EventKind = StreamingEventKind.Status,
                                        Status = tweet.Fix()
                                    };
                                var dmsg = s.DeserializeJson<DirectMessage>();
                                if (dmsg.IdStr != null)
                                    return new StreamingElement()
                                    {
                                        EventKind = StreamingEventKind.DirectMessage,
                                        DirectMessage = dmsg.Fix()
                                    };
                                var deleted = s.DeserializeJson<StreamingDelete>();
                                if (deleted.Fix().Id != 0)
                                    return new StreamingElement()
                                    {
                                        EventKind = StreamingEventKind.Delete,
                                        DeletedId = deleted.Id
                                    };
                                // can't decode
                                return desz.ToStreamingElement();
                            case StreamingEventKind.Block:
                            case StreamingEventKind.Unblock:
                            case StreamingEventKind.Follow:
                            case StreamingEventKind.Unfollow:
                            case StreamingEventKind.UserUpdate:
                                return s.DeserializeJson<StreamingEvent>().Fix().ToStreamingElement();
                            case StreamingEventKind.Favorite:
                            case StreamingEventKind.Unfavorite:
                                return s.DeserializeJson<StreamingEventStatus>().Fix().ToStreamingElement();
                            case StreamingEventKind.ListCreated:
                            case StreamingEventKind.ListDestroyed:
                            case StreamingEventKind.ListUpdated:
                            case StreamingEventKind.ListMemberAdded:
                            case StreamingEventKind.ListMemberRemoved:
                            case StreamingEventKind.ListUserSubscribed:
                            case StreamingEventKind.ListUserUnsubscribed:
                                return s.DeserializeJson<StreamingEventList>().Fix().ToStreamingElement();
                            default:
                                throw new InvalidOperationException("Unknown StreamingEventKind: " + desz.EventKind.ToString()); // EventKind が設定されていないことはないはず
                        }
                    }
                    catch
                    {
                        return new StreamingElement();
                    }
                })
                .Repeat();
        }
    }
}
