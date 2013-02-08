using Meton.Liegen.DataModels;
using Meton.Liegen.DataModels.Entity;
using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;

namespace Meton.Liegen.Method.Rest
{
    public static class Urls
    {
        public static IObservable<ApiResponse<Url>> UrlShorten(
            this AccessToken info,
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
                .ReadResponse<Url>();
        }

        public static IObservable<ApiResponse<Url>> UrlCount(
            this AccessToken info,
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
                .ReadResponse<Url>();
        }
    }
}
