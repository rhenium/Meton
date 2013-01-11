using Meton.Liegen.DataModels;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;

namespace Meton.Liegen.Method.Rest
{
    public static class Friendships
    {
        #region FollowersIds
        public static IObservable<IdsResponse> FollowersIds(
            this AccountInfo info,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, cursor: cursor);
        }

        public static IObservable<IdsResponse> FollowersIds(
            this AccountInfo info,
            long userId,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, userId: userId, cursor: cursor);
        }

        public static IObservable<IdsResponse> FollowersIds(
            this AccountInfo info,
            string screenName,
            int cursor = -1)
        {
            return Friendships.FollowersIdsApi(info, screenName: screenName, cursor: cursor);
        }

        private static IObservable<IdsResponse> FollowersIdsApi(
            AccountInfo info,
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
                .ReadApiLimits(info, Endpoints.FollowersIds)
                .Parse<IdsResponse>();
        }
        #endregion

        #region FriendsIds
        public static IObservable<IdsResponse> FriendsIds(
            this AccountInfo info,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, cursor: cursor);
        }

        public static IObservable<IdsResponse> FriendsIds(
            this AccountInfo info,
            long userId,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, userId: userId, cursor: cursor);
        }

        public static IObservable<IdsResponse> FriendsIds(
            this AccountInfo info,
            string screenName,
            int cursor = -1)
        {
            return Friendships.FriendsIdsApi(info, screenName: screenName, cursor: cursor);
        }

        private static IObservable<IdsResponse> FriendsIdsApi(
            AccountInfo info,
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
                .ReadApiLimits(info, Endpoints.FriendsIds)
                .Parse<IdsResponse>();
        }
        #endregion
    }
}
