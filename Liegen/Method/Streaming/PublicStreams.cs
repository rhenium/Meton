using Meton.Liegen.DataModels.Streaming;
using Meton.Liegen.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Meton.Liegen.Method.Streaming
{
    public static class PublicStreams
    {
        public static IObservable<StreamingElement> PublicStreamsSample(
            this AccessToken info,
            string delimited = null,
            bool? stallWarnings = null)
        {
            var param = new ParameterCollection()
            {
                {"delimited", delimited},
                {"stall_warnings", stallWarnings}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.PublicStreamsSample)
                .SetParameters(param)
                .GetResponse()
                .ParseStreamingResponseMessage();
        }
    }
}
