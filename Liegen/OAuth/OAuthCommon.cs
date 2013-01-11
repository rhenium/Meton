using Meton.Liegen.Net;
using Meton.Liegen.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Meton.Liegen.OAuth
{
    public static class OAuthCommon
    {
        public static ParameterCollection ConstructBasicParameters(this Consumer consumer, Uri uri, HttpMethod method, Token token, IEnumerable<Parameter> addParam)
        {
            var parameters = new ParameterCollection
            {
                {"oauth_version", "1.0"},
                {"oauth_nonce", Guid.NewGuid().ToString("N")},
                {"oauth_timestamp", DateTime.UtcNow.GetUnixEpochTimeByDateTime()},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_consumer_key", consumer.ConsumerKey}
            };
            if (token != null)
            {
                parameters.Add("oauth_token", token.Key);
            }

            var normalizedUrl = string.Format("{0}://{1}", uri.Scheme, uri.Host);
            if (!((uri.Scheme == "http" && uri.Port == 80) || (uri.Scheme == "https" && uri.Port == 443)))
            {
                normalizedUrl += ":" + uri.Port;
            }
            normalizedUrl += uri.AbsolutePath;


            var signatureBase =
                method.Method +
                "&" + normalizedUrl.UrlEncode() +
                "&" + parameters.Concat(addParam).OrderBy(p => p.Name).ThenBy(p => p.Value).ToUrlParameter().UrlEncode();

            Debug.WriteLine(signatureBase);

            var hmacKeyBase = consumer.ConsumerSecret.UrlEncode() + "&" +
                (token == null ? "" : token.Secret.UrlEncode());

            var signature = new HMACSHA1(Encoding.UTF8.GetBytes(hmacKeyBase))
                .Using(hmacsha1 => Convert.ToBase64String(hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(signatureBase))).UrlEncode());

            parameters.Add(new Parameter("oauth_signature", signature));

            return new ParameterCollection(
                parameters
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Value));
        }

        public static string BuildAuthorizationHeader(IEnumerable<Parameter> parameters)
        {
            return parameters
                .Where(p => p != null && p.Value != null)
                .Select(p => p.Name + "=\"" + p.Value.ToString() + "\"")
                .Aggregate(new StringBuilder(), (sb, o) => (sb.Length == 0) ? sb.Append(o) : sb.Append(", " + o))
                .ToString();
        }

        public static IObservable<T> GetTokenResponse<T>(
            string url,
            ParameterCollection parameters,
            Func<string, string, T> tokenFactory,
            Consumer consumer,
            Token token = null,
            string realm = null)
            where T : Token
        {
            var handler = new HttpClientHandler();
            handler.UseProxy = NetworkSettings.Proxy != null;
            handler.Proxy = NetworkSettings.Proxy;
            var client = new HttpClient(new OAuthMessageHandler(consumer, token, realm, parameters, handler));
            client.Timeout = NetworkSettings.Timeout;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            NetworkSettings.GetOptionRequestHeaders.Select(p => { requestMessage.Headers.Add(p.Key, p.Value); return p; });
            requestMessage.Content = new FormUrlEncodedContent(parameters.Where(p => p.Value != null).Select(p => new KeyValuePair<string, string>(p.Name, p.Value.ToString())));
            return client.SendAsync(requestMessage).ToObservable()
                .SelectMany(p => p.Content.ReadAsStringAsync().ToObservable())
                .Select(str =>
                {
                    var ret = str.Split('&').Select(s => s.Split('=')).ToDictionary(s => s.First(), s => s.Last());

                    return tokenFactory(ret["oauth_token"].UrlDecode(), ret["oauth_token_secret"].UrlDecode());
                });
        }
    }
}
