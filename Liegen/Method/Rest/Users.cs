using Meton.Liegen.DataModels;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;

namespace Meton.Liegen.Method.Rest
{
    public static class Users
    {
        #region UsersShow
        public static IObservable<User> UsersShow(
            this AccountInfo info,
            long userId)
        {
            return Users.UsersShowAPI(info, userId: userId);
        }

        public static IObservable<User> UsersShow(
            this AccountInfo info,
            string screenName)
        {
            return Users.UsersShowAPI(info, screenName: screenName);
        }

        private static IObservable<User> UsersShowAPI(
            AccountInfo info,
            long? userId = null,
            string screenName = null)
        {
            var param = new ParameterCollection()
            {
                {"user_id", userId},
                {"screen_name", screenName},
                {"include_entities", true}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.UsersShow)
                .SetParameters(param)
                .GetResponse()
                .ReadApiLimits(info, Endpoints.UsersShow)
                .Parse<User>()
                .Select(user => user.Fix());
        }
        #endregion

        #region UsersLookup
        public static IObservable<User> UsersLookup(
            this AccountInfo info,
            params long[] userId)
        {
            return Users.UsersLookupAPI(info, userId: userId);
        }

        public static IObservable<User> UsersLookup(
            this AccountInfo info,
            string screenName)
        {
            return Users.UsersLookupAPI(info, screenName: screenName);
        }

        private static IObservable<User> UsersLookupAPI(
            AccountInfo info,
            long[] userId = null,
            string screenName = null)
        {
            var param = new ParameterCollection()
            {
                {"include_entities", true}
            };

            if (userId == null)
            {
                param.Add("screen_name", screenName);
            }
            else
            {
                param.Add("user_id", string.Join(",", userId));
            }

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.UsersLookup)
                .SetParameters(param)
                .GetResponse()
                .ReadApiLimits(info, Endpoints.UsersLookup)
                .ParseArray<User>()
                .Select(user => user.Fix());
        }
        #endregion
    }
}
