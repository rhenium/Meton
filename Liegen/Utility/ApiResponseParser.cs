using Meton.Liegen.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.Utility
{
    public static class ApiResponseParser
    {
        public static IObservable<ApiResponse<T>> ReadResponse<T>(this IObservable<HttpResponseMessage> res)
            where T : IRawApiResponse
        {
            return res
                .Select(message => new ApiResponse<T>(
                    message.Content
                        .ReadAsStringAsync()
                        .ToObservable()
                        .Select(s => s.DeserializeJson<T>()), message));
        }

        public static IObservable<ApiResponse<T>> ReadArrayResponse<T>(this IObservable<HttpResponseMessage> res)
            where T : IRawApiResponse
        {
            return res
                .Select(message => new ApiResponse<T>(
                    message.Content
                        .ReadAsStringAsync()
                        .ToObservable()
                        .Select(s => s.DeserializeJson<List<T>>())
                        .SelectMany(_ => _), message));
        }

        public static T DeserializeJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}