using Meton.Liegen.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.OAuth
{
    public class OAuthClient
    {
        private AccessToken _AccessToken;
        private HttpMethod _Method;
        private string _Endpoint;
        private ParameterCollection _ParameterCollection;
        private ContentType _ContentType;

        public OAuthClient(AccessToken accessToken, HttpMethod method, ContentType contentType)
        {
            _AccessToken = accessToken;
            _Method = method;
            _ContentType = contentType;
        }

        public OAuthClient SetEndpoint(string value)
        {
            _Endpoint = value;
            return this;
        }

        public OAuthClient SetParameters(ParameterCollection value)
        {
            _ParameterCollection = value;
            return this;
        }

        public IObservable<HttpResponseMessage> GetResponse()
        {
            var addParam = new ParameterCollection();
            var requestMessage = new HttpRequestMessage(_Method, _Endpoint);
            NetworkSettings.GetOptionRequestHeaders.Select(p => { requestMessage.Headers.Add(p.Key, p.Value); return p; });

            if (_Method == HttpMethod.Get)
            {
                var requestUri = _Endpoint;
                var uriParameter = _ParameterCollection.ToUrlParameter();
                if (uriParameter.Length > 0)
                {
                    requestUri += "?" + uriParameter;
                }

                requestMessage.RequestUri = new Uri(requestUri);
                addParam = _ParameterCollection;
            }
            else if (_Method == HttpMethod.Post)
            {
                switch (_ContentType)
                {
                    case Net.ContentType.FormUrlEncoded:
                        requestMessage.Content = new FormUrlEncodedContent(_ParameterCollection.Where(p => p.Value != null).Select(p => new KeyValuePair<string, string>(p.Name, p.Value.ToString())));
                        addParam = _ParameterCollection;
                        break;
                    case Net.ContentType.MultipartFormData:
                        requestMessage.Content = _ParameterCollection.Where(p => p.Value != null).Aggregate(new MultipartFormDataContent(), (c, p) =>
                        {
                            if (p.FileName == null)
                            {
                                var sc = new StringContent(p.Value.ToString());
                                c.Add(sc, "\"" + p.Name + "\""); // TODO: ""を自分で付け加えないとname=statusとなってしまい無視されてしまう/あとでよく調べる必要あり
                            }
                            else
                            {
                                var bac = new ByteArrayContent((byte[])p.Value);
                                c.Add(bac, p.Name, "\"" + p.FileName + "\"");
                            }
                            return c;
                        });
                        break;
                }
            }

            var handler = new HttpClientHandler();
            handler.UseProxy = NetworkSettings.Proxy != null;
            handler.Proxy = NetworkSettings.Proxy;
            var client = new HttpClient(new OAuthMessageHandler(_AccessToken.Consumer, _AccessToken, null, addParam, handler));
            client.Timeout = NetworkSettings.Timeout;

            return client
                .SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
                .ToObservable();
        }
    }
}
