using Meton.Liegen.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Meton.Liegen.Utility
{
    public static class ApiResponseParser
    {
        public static IObservable<T> Parse<T>(this IObservable<HttpResponseMessage> res)
            where T : ApiResponseBase
        {
            return res
                .SelectMany(p => p.Content.ReadAsStringAsync())
                .DeserializeJson<T>();
        }

        public static IObservable<T> ParseArray<T>(this IObservable<HttpResponseMessage> res)
            where T : ApiResponseBase
        {
            return res
                .SelectMany(p => p.Content.ReadAsStringAsync())
                .DeserializeJson<List<T>>()
                .SelectMany(m => m);
        }

        public static IObservable<T> DeserializeJson<T>(this IObservable<string> json)
        {
            return json.Select(s => s.DeserializeJson<T>());
        }

        public static T DeserializeJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
