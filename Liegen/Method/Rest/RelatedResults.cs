using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.Method.Rest
{
    public static class RelatedResults
    {
        public static IObservable<string> RelatedResultsShow(
            this AccessToken info,
            long id,
            bool? includeEntities = null,
            bool? includeCards = null)
        {
            var param = new ParameterCollection()
            {
                {"include_entities", includeEntities},
                {"include_cards", includeCards}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.BaseUriApiV1 + "related_results/show/" + id.ToString() + ".json")
                .SetParameters(param)
                .GetResponse()
                .SelectMany(p => p.Content.ReadAsStringAsync().ToObservable());
        }
    }
}
