using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using System.Collections.Generic;
using System.Net.Http;

namespace Meton.Liegen
{
    public class AccountInfo
    {
        public AccessToken AccessToken { get; private set; }

        private Dictionary<string, ApiRateLimits> _rateLimits;
        public Dictionary<string, ApiRateLimits> RateLimits { get { return this._rateLimits; } }

        public AccountInfo(AccessToken accessToken)
        {
            this.AccessToken = accessToken;
            this._rateLimits = new Dictionary<string, ApiRateLimits>();
        }

        public OAuthClient GetClient(HttpMethod method, ContentType contentType = Net.ContentType.FormUrlEncoded)
        {
            return this.AccessToken.GetClient(method, contentType);
        }

        public AccountInfo SetRateLimit(string endpoint, ApiRateLimits rateLimits)
        {
            if (this.RateLimits.ContainsKey(endpoint))
            {
                this.RateLimits[endpoint] = rateLimits;
            }
            else
            {
                this.RateLimits.Add(endpoint, rateLimits);
            }
            return this;
        }
    }
}
