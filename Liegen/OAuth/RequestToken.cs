using Meton.Liegen.Method;
using System;

namespace Meton.Liegen.OAuth
{
    /// <summary>
    /// OAuth Request Token.
    /// </summary>
    public class RequestToken : Token
    {
        public RequestToken(Consumer consumer, string key, string secret)
            : base(consumer, key, secret)
        { }

        public IObservable<AccessToken> GetAccessToken(string verifier)
        {
            var parameters = new ParameterCollection
            {
                { "oauth_verifier", verifier }
            };
            return OAuthCommon.GetTokenResponse(
                Endpoints.OAuthAccessTokenUrl,
                parameters,
                (key, secret) => new AccessToken(this.Consumer, key, secret),
                this.Consumer,
                this);
        }

        public string GetAuthorizeUrl()
        {
            return Endpoints.OAuthAuthorizeUrl + "?oauth_token=" + this.Key;
        }
    }
}
