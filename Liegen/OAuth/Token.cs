using System;

namespace Meton.Liegen.OAuth
{
    /// <summary>
    /// Base class of RequestToken/AccessToken.
    /// </summary>
    public abstract class Token
    {
        public Consumer Consumer { get; protected set; }
        public string Key { get; protected set; }
        public string Secret { get; protected set; }

        protected Token(Consumer consumer, string key, string secret)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException("consumer");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (secret == null)
            {
                throw new ArgumentNullException("secret");
            }

            this.Consumer = consumer;
            this.Key = key;
            this.Secret = secret;
        }
    }
}
