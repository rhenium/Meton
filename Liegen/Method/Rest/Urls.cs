using Meton.Liegen.DataModels;
using Meton.Liegen.Net;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;

namespace Meton.Liegen.Method.Rest
{
    public static class Urls
    {
        public static IObservable<Url> UrlShorten(
            this AccountInfo info,
            string url)
        {
            var param = new ParameterCollection()
            {
                {"url", url}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.UrlsShorten)
                .SetParameters(param)
                .GetResponse()
                .Parse<Url>();
        }

        public static IObservable<UrlCount> UrlCount(
            this AccountInfo info,
            string url)
        {
            var param = new ParameterCollection()
            {
                {"url", url}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.UrlsCount)
                .SetParameters(param)
                .GetResponse()
                .Parse<UrlCount>();
        }
    }
}
