using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace Meton.Liegen.OAuth
{
    public class OAuthMessageHandler : DelegatingHandler
    {
        private Consumer _Consumer;
        private Token _Token;
        private IEnumerable<Parameter> _AddParam;
        private string _Realm;

        public OAuthMessageHandler(Consumer consumer, Token token, string realm, IEnumerable<Parameter> addParam, HttpMessageHandler innerHandler)
            :base(innerHandler)
        {
            _Consumer = consumer;
            _Token = token;
            _AddParam = addParam;
            _Realm = realm;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var signature = OAuthCommon.ConstructBasicParameters(_Consumer, request.RequestUri, request.Method, _Token, _AddParam);
            if (_Realm != null)
            {
                signature = new ParameterCollection(new[] { new Parameter("realm", _Realm) }.Concat(signature));
            }
            var authHeader = OAuthCommon.BuildAuthorizationHeader(signature);

            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
