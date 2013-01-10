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
            return Users.UsersShowApi(info, userId: userId);
        }

        public static IObservable<User> UsersShow(
            this AccountInfo info,
            string screenName)
        {
            return Users.UsersShowApi(info, screenName: screenName);
        }

        private static IObservable<User> UsersShowApi(
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
            return Users.UsersLookupApi(info, userId: userId);
        }

        public static IObservable<User> UsersLookup(
            this AccountInfo info,
            string screenName)
        {
            return Users.UsersLookupApi(info, screenName: screenName);
        }

        private static IObservable<User> UsersLookupApi(
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

        #region BlocksCreate
        public static IObservable<User> BlocksCreate(
            this AccountInfo info,
            long userId)
        {
            return Users.BlocksCreateApi(info, userId: userId);
        }

        public static IObservable<User> BlocksCreate(
            this AccountInfo info,
            string screenName)
        {
            return Users.BlocksCreateApi(info, screenName: screenName);
        }

        public static IObservable<User> BlocksCreateApi(
            AccountInfo info,
            long? userId = null,
            string screenName = null)
        {
            var param = new ParameterCollection()
            {
                {"user_id", userId},
                {"screen_name", screenName}
            };

            return info
                .GetClient(HttpMethod.Post)
                .SetEndpoint(Endpoints.BlocksCreate)
                .SetParameters(param)
                .GetResponse()
                .Parse<User>()
                .Select(_ => _.Fix());
        }
        #endregion

        #region BlocksDestroy
        public static IObservable<User> BlocksDestroy(
            this AccountInfo info,
            long userId)
        {
            return Users.BlocksDestroyApi(info, userId: userId);
        }

        public static IObservable<User> BlocksDestroy(
            this AccountInfo info,
            string screenName)
        {
            return Users.BlocksDestroyApi(info, screenName: screenName);
        }

        public static IObservable<User> BlocksDestroyApi(
            AccountInfo info,
            long? userId = null,
            string screenName = null)
        {
            var param = new ParameterCollection()
            {
                {"user_id", userId},
                {"screen_name", screenName}
            };

            return info
                .GetClient(HttpMethod.Post)
                .SetEndpoint(Endpoints.BlocksDestroy)
                .SetParameters(param)
                .GetResponse()
                .Parse<User>()
                .Select(_ => _.Fix());
        }
        #endregion
    }
}
