using Meton.Liegen.DataModels;
using Meton.Liegen.DataModels.Account.Generate;
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
        public static IObservable<Tuple<AccessToken, User>> AccountGenerate(
            this AccountInfo info,
            string screenName,
            string email,
            string password,
            string name,
            string lang = null,
            string timeZone = null,
            Consumer newConsumer = null)
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
                .SelectMany(res =>
                {
                    //string accessToken = res.Headers.GetValues("X-Twitter-New-Account-OAuth-Access-Token").FirstOrDefault();
                    //string accessSecret = res.Headers.GetValues("X-Twitter-New-Account-OAuth-Secret").FirstOrDefault();

                    return res.Parse<User>()
                        .Select(u => new Tuple<AccessToken, User>(/*new AccessToken(newConsumer, accessToken, accessSecret)*/null, u));
                });
        }
    }
}
