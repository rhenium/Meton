using System;

namespace Meton.Liegen.OAuth
{
    /// <summary>
    /// Base class of RequestToken/AccessToken.
    /// </summary>
    public abstract class Token
    {
        public Consumer Consumer { get; private set; }
        public string Key { get; private set; }
        public string Secret { get; private set; }

        protected Token(Consumer consumer, string key, string secret)
        {
            if (consumer == null || key == null || secret == null)
            {
                throw new InvalidOperationException("key/secret: null");
            }
            this.Consumer = consumer;
            this.Key = key;
            this.Secret = secret;
        }
    }
}
