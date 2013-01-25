using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.Method.Rest
{
    public static class Application
    {
        public static IObservable<string> RateLimitStatus(
            this AccessToken info,
            string resources = null)
        {
            var param = new ParameterCollection()
            {
                {"resources", resources}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.ApplicationRateLimitStatus)
                .SetParameters(param)
                .GetResponse()
                .SelectMany(p => p.Content.ReadAsStringAsync());
        }
    }
}
