using Meton.Liegen.DataModels;
using Meton.Liegen.DataModels.Streaming;
using Meton.Liegen.Net;
using Meton.Liegen.Utility;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.Method.Streaming
{
    public static class UserStreams
    {
        public static IConnectableObservable<StreamingElement> UserStream(
            this AccountInfo info,
            string delimited = null,
            bool? stallWarnings = null,
            string with = null,
            string replies = null,
            string track = null,
            string locations = null)
        {
            var param = new ParameterCollection()
            {
                {"delimited", delimited},
                {"stall_warnings", stallWarnings},
                {"with", with},
                {"replies", replies},
                {"track", track},
                {"locations", locations}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.UserStream)
                .SetParameters(param)
                .GetResponse()
                .ParseStreamingResponse();
        }

        private static IConnectableObservable<StreamingElement> ParseStreamingResponse(this IObservable<HttpResponseMessage> res)
        {
            return res
                .SelectMany(p => p.Content.ReadAsStreamAsync().ToObservable())
                .Select(p => new StreamReader(p))
                .TakeWhile(sr => !sr.EndOfStream)
                .Select(sr => sr.ReadLine())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s =>
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
                            throw new InvalidOperationException(); // EventKind が設定されていないことはないはず
                    }
                })
                .Publish();
        }
    }
}
