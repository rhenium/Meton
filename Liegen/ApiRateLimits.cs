using Meton.Liegen.Utility;
using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Reactive.Linq;

namespace Meton.Liegen
{
    public class ApiRateLimits
    {
        public int Limit { get; set; }
        public int Remaining { get; set; }
        public DateTime Reset { get; set; }
    }

    public static class RateLimitsExtensions
    {
        public static IObservable<HttpResponseMessage> ReadApiLimits(this IObservable<HttpResponseMessage> res, AccountInfo info, string endpoint)
        {
            return res.Do(r =>
            {
                var rateLimits = new ApiRateLimits();
                int limit;
                if (int.TryParse(r.Headers.GetValues("X-Rate-Limit-Limit").FirstOrDefault(), out limit))
                {
                    rateLimits.Limit = limit;
                }
                int remaining;
                if (int.TryParse(r.Headers.GetValues("X-Rate-Limit-Remaining").FirstOrDefault(), out remaining))
                {
                    rateLimits.Remaining = remaining;
                }
                long reset;
                if (long.TryParse(r.Headers.GetValues("X-Rate-Limit-Reset").FirstOrDefault(), out reset))
                {
                    rateLimits.Reset = reset.GetDateTimeByUnixEpochTime();
                }

                info.SetRateLimit(endpoint, rateLimits);
            });
        }

    }

}
