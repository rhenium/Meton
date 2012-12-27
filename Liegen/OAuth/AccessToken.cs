using Meton.Liegen.Net;
using System.Net.Http;

namespace Meton.Liegen.OAuth
{
    /// <summary>
    /// OAuth Access Token.
    /// </summary>
    public class AccessToken : Token
    {
        public AccessToken(Consumer consumer, string key, string secret)
            : base(consumer, key, secret)
        { }

        public OAuthClient GetClient(HttpMethod method, ContentType contentType = Net.ContentType.FormUrlEncoded)
        {
            return new OAuthClient(this, method, contentType);
        }
    }
}
