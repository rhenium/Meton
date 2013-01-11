using Meton.Liegen.Method;
using System;

namespace Meton.Liegen.OAuth
{
    public class Consumer
    {
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }

        public Consumer(string consumerKey, string consumerSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
        }

        public IObservable<RequestToken> GetRequestToken(string oauthCallback = "oob", XAuthAccessType? xauthAccessType = null)
        {
            var parameters = new ParameterCollection
            {
                { "oauth_callback", oauthCallback },
                { "x_auth_access_type", xauthAccessType.HasValue ? xauthAccessType.Value.ToStringExt() : null }
            };

            return OAuthCommon.GetTokenResponse(
                Endpoints.OAuthRequestTokenUrl,
                parameters,
                (key, secret) => new RequestToken(this, key, secret),
                this);
        }

        // xAuth
        public IObservable<AccessToken> GetAccessToken(string username, string password, string mode = "client_auth")
        {
            var parameters = new ParameterCollection
            {
                {"x_auth_username", username},
                {"x_auth_password", password},
                {"x_auth_mode", mode}
            };

            return OAuthCommon.GetTokenResponse(
                Endpoints.OAuthAccessTokenUrl,
                parameters,
                (key, secret) => new AccessToken(this, key, secret),
                this);
        }

        // Signup
        public IObservable<AccessToken> Signup(
            string screenName,
            string email,
            string password,
            string fullname,
            string lang,
            Consumer newConsumer)
        {
            var parameters = new ParameterCollection
            {
                { "screen_name", screenName },
                { "email", email },
                { "password", password },
                { "fullname", fullname },
                { "lang", lang }
            };

            return OAuthCommon.GetTokenResponse(
                Endpoints.OAuthSignupUrl,
                parameters,
                (key, secret) => new AccessToken(newConsumer, key, secret),
                this,
                null,
                "http://api.twitter.com/");
        }
    }
}
