using Meton.Liegen.DataModels.Parts;
using Meton.Liegen.Utility;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;

namespace Meton.Liegen.DataModels
{
    public abstract class ApiResponseBase
    {
        [JsonProperty("errors")]
        public ErrorMessage[] ErrorMessages { get; protected set; }

        // RateLimits
        public int Limit { get; internal set; }
        public int Remaining { get; internal set; }
        public DateTime Reset { get; internal set; }

        // Response Headers
        public Dictionary<string, IEnumerable<string>> ResponseHeaders { get; internal set; }
    }

    public static class ApiResponseBaseExtensions
    {
        public static T SetResponseHeaders<T>(this T response, HttpResponseMessage responseMessage)
            where T : ApiResponseBase
        {
            // Limits
            int limit;
            if (int.TryParse(responseMessage.Headers.GetValues("X-Rate-Limit-Limit").FirstOrDefault(), out limit))
            {
                response.Limit = limit;
            }
            int remaining;
            if (int.TryParse(responseMessage.Headers.GetValues("X-Rate-Limit-Remaining").FirstOrDefault(), out remaining))
            {
                response.Remaining = remaining;
            }
            long reset;
            if (long.TryParse(responseMessage.Headers.GetValues("X-Rate-Limit-Reset").FirstOrDefault(), out reset))
            {
                response.Reset = reset.GetDateTimeByUnixEpochTime();
            }

            // Other headers
            response.ResponseHeaders = responseMessage.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return response;
        }
    }
}
