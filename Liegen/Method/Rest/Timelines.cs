using Meton.Liegen.DataModels;
using Meton.Liegen.Net;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;

namespace Meton.Liegen.Method.Rest
{
    public static class Timelines
    {
        public static IObservable<Status> HomeTimeline(
            this AccountInfo info,
            int? count = null,
            long? sinceId = null,
            long? maxId = null,
            bool? trimUser = null,
            bool? excludeReplies = null,
            bool? contributorDetails = null,
            bool? includeEntities = null)
        {
            var param = new ParameterCollection()
            {
                {"count", count},
                {"since_id", sinceId},
                {"max_id", maxId},
                {"trim_user", trimUser},
                {"exclude_replies", excludeReplies},
                {"contributor_details", contributorDetails},
                {"include_entities", includeEntities}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.BaseUriApiV11 + Endpoints.StatusesHomeTimeline)
                .SetParameters(param)
                .GetResponse()
                .ReadApiLimits(info, Endpoints.StatusesHomeTimeline)
                .ParseArray<Status>()
                .Select(status => status.Fix());
        }

    }
}
