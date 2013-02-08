using Meton.Liegen.DataModels;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;

namespace Meton.Liegen.Method.Rest
{
    public static class Account
    {
        public static IObservable<Tuple<AccessToken, ApiResponse<User>>> AccountGenerate(
            this AccessToken info,
            Consumer newConsumer,
            string screenName,
            string email,
            string password,
            string name,
            string lang = null,
            string timeZone = null)
        {
            var param = new ParameterCollection()
            {
                {"screen_name", screenName},
                {"email", email},
                {"password", password},
                {"name", name},
                {"lang", lang},
                {"time_zone", timeZone}
            };

            return info
                .GetClient(HttpMethod.Post)
                .SetEndpoint(Endpoints.AccountGenerate)
                .SetParameters(param)
                .GetResponse()
                .ReadResponse<User>()
                .Select(res =>
                {
                    string accessToken = res.ResponseHeaders["X-Twitter-New-Account-OAuth-Access-Token"].First();
                    string accessSecret = res.ResponseHeaders["X-Twitter-New-Account-OAuth-Secret"].First();

                    return new Tuple<AccessToken, ApiResponse<User>>(new AccessToken(newConsumer, accessToken, accessSecret), res);
                });
        }
    }
}
