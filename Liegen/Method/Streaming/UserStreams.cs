using Meton.Liegen.DataModels;
using Meton.Liegen.DataModels.Streaming;
using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace Meton.Liegen.Method.Streaming
{
    public static class UserStreams
    {
        public static IObservable<StreamingElement> UserStreamsUser(
            this AccessToken info,
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
                .ParseStreamingResponseMessage();
        }
    }
}
