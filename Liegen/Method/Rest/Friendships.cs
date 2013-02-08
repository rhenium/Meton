using Meton.Liegen.DataModels;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;

namespace Meton.Liegen.Method.Rest
{
    public static class Friendships
    {
        #region FollowersIds
        public static IObservable<ApiResponse<IdsResponse>> FollowersIds(
            this AccessToken info,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, cursor: cursor);
        }

        public static IObservable<ApiResponse<IdsResponse>> FollowersIds(
            this AccessToken info,
            long userId,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, userId: userId, cursor: cursor);
        }

        public static IObservable<ApiResponse<IdsResponse>> FollowersIds(
            this AccessToken info,
            string screenName,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, screenName: screenName, cursor: cursor);
        }

        private static IObservable<ApiResponse<IdsResponse>> FollowersIdsApi(
            AccessToken info,
            long? userId = null,
            string screenName = null,
            int cursor = -1)
        {
            var param = new ParameterCollection()
            {
                {"user_id", userId},
                {"screen_name", screenName},
                {"cursor", cursor}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.FollowersIds)
                .SetParameters(param)
                .GetResponse()
                .ReadResponse<IdsResponse>();
        }
        #endregion

        #region FriendsIds
        public static IObservable<ApiResponse<IdsResponse>> FriendsIds(
            this AccessToken info,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, cursor: cursor);
        }

        public static IObservable<ApiResponse<IdsResponse>> FriendsIds(
            this AccessToken info,
            long userId,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, userId: userId, cursor: cursor);
        }

        public static IObservable<ApiResponse<IdsResponse>> FriendsIds(
            this AccessToken info,
            string screenName,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, screenName: screenName, cursor: cursor);
        }

        private static IObservable<ApiResponse<IdsResponse>> FriendsIdsApi(
            AccessToken info,
            long? userId = null,
            string screenName = null,
            int cursor = -1)
        {
            var param = new ParameterCollection()
            {
                {"user_id", userId},
                {"screen_name", screenName},
                {"cursor", cursor}
            };

            return info
                .GetClient(HttpMethod.Get)
                .SetEndpoint(Endpoints.FriendsIds)
                .SetParameters(param)
                .GetResponse()
                .ReadResponse<IdsResponse>();
        }
        #endregion
    }
}
