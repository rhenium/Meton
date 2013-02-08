using Meton.Liegen.DataModels;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;

namespace Meton.Liegen.Method.Rest
{
    public static class Users
    {
        #region UsersShow
        public static IObservable<ApiResponse<User>> UsersShow(
            this AccessToken info,
            long userId)
        {
            return Users.UsersShowApi(info, userId: userId);
        }

        public static IObservable<ApiResponse<User>> UsersShow(
            this AccessToken info,
            string screenName)
        {
            return Users.UsersShowApi(info, screenName: screenName);
        }

        private static IObservable<ApiResponse<User>> UsersShowApi(
            AccessToken info,
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
                .ReadResponse<User>();
        }
        #endregion

        #region UsersLookup
        public static IObservable<ApiResponse<User>> UsersLookup(
            this AccessToken info,
            params long[] userId)
        {
            return Users.UsersLookupApi(info, userId: userId);
        }

        public static IObservable<ApiResponse<User>> UsersLookup(
            this AccessToken info,
            string screenName)
        {
            return Users.UsersLookupApi(info, screenName: screenName);
        }

        private static IObservable<ApiResponse<User>> UsersLookupApi(
            AccessToken info,
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
                .ReadArrayResponse<User>();
        }
        #endregion

        #region BlocksCreate
        public static IObservable<ApiResponse<User>> BlocksCreate(
            this AccessToken info,
            long userId)
        {
            return Users.BlocksCreateApi(info, userId: userId);
        }

        public static IObservable<ApiResponse<User>> BlocksCreate(
            this AccessToken info,
            string screenName)
        {
            return Users.BlocksCreateApi(info, screenName: screenName);
        }

        public static IObservable<ApiResponse<User>> BlocksCreateApi(
            AccessToken info,
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
                .ReadResponse<User>();
        }
        #endregion

        #region BlocksDestroy
        public static IObservable<ApiResponse<User>> BlocksDestroy(
            this AccessToken info,
            long userId)
        {
            return Users.BlocksDestroyApi(info, userId: userId);
        }

        public static IObservable<ApiResponse<User>> BlocksDestroy(
            this AccessToken info,
            string screenName)
        {
            return Users.BlocksDestroyApi(info, screenName: screenName);
        }

        public static IObservable<ApiResponse<User>> BlocksDestroyApi(
            AccessToken info,
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
                .ReadResponse<User>();
        }
        #endregion
    }
}
