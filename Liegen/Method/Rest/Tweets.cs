using Meton.Liegen.DataModels;
using Meton.Liegen.Net;
using Meton.Liegen.OAuth;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;

namespace Meton.Liegen.Method.Rest
{
    public static class Tweets
    {
        public static IObservable<Status> Update(
            this AccessToken info,
            string status,
            long? inReplyToStatusId = null,
            double? latitude = null,
            double? longitude = null,
            string placeId = null,
            bool? displayCoordinates = null,
            bool? trimUser = null)
        {
            var param = new ParameterCollection()
            {
                {"status", status},
                {"in_reply_to_status_id", inReplyToStatusId},
                {"lat", latitude},
                {"long", longitude},
                {"place_id", placeId},
                {"display_coordinates", displayCoordinates},
                {"trim_user", trimUser}
            };

            return info
                .GetClient(HttpMethod.Post)
                .SetEndpoint(Endpoints.StatusesUpdate)
                .SetParameters(param)
                .GetResponse()
                .Parse<Status>()
                .Select(status_ => status_.Fix());
        }

        public static IObservable<Status> UpdateWithMedia(
            this AccessToken info,
            string status,
            UploadFile[] media,
            bool? possiblySensitive = null,
            long? inReplyToStatusId = null,
            double? latitude = null,
            double? longitude = null,
            string placeId = null,
            bool? displayCoordinates = null)
        {
            var param = new ParameterCollection()
            {
                {"status", status},
                {"possibly_sensitive", possiblySensitive},
                {"in_reply_to_status_id", inReplyToStatusId},
                {"lat", latitude},
                {"long", longitude},
                {"place_id", placeId},
                {"display_coordinates", displayCoordinates}
            };

            foreach (var m in media)
            {
                param.Add(new Parameter("media[]", m.Data, m.FileName));
            }

            return info
                .GetClient(HttpMethod.Post, ContentType.MultipartFormData)
                .SetEndpoint(Endpoints.StatusesUpdateWithMedia)
                .SetParameters(param)
                .GetResponse()
                .Parse<Status>()
                .Select(status_ => status_.Fix());
        }
    }
}
