using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Meton.Liegen.Utility
{
    public static class JsonUtility
    {
        public static IObservable<T> Parse<T>(this HttpResponseMessage res)
        {
            return res
                .Content.ReadAsStringAsync().ToObservable()
                .DeserializeJson<T>();
        }

        public static IObservable<T> ParseArray<T>(this HttpResponseMessage res)
        {
            return res
                .Parse<List<T>>()
                .SelectMany(m => m);
        }

        public static IObservable<T> Parse<T>(this IObservable<HttpResponseMessage> res)
        {
            return res
                .SelectMany(p => p.Content.ReadAsStringAsync().ToObservable())
                .DeserializeJson<T>();
        }

        public static IObservable<T> ParseArray<T>(this IObservable<HttpResponseMessage> res)
        {
            return res
                .Parse<List<T>>()
                .SelectMany(m => m);
        }

        public static IObservable<T> DeserializeJson<T>(this IObservable<string> json)
        {
            return json.Select(s => s.DeserializeJson<T>());
        }

        public static T DeserializeJson<T>(this string json)
        {
            /*return new StringReader(json)
                .Using(sr => new JsonTextReader(sr)
                    .Using(js => new JsonSerializer()
                        .Deserialize<T>(js)));*/
            System.Diagnostics.Debug.WriteLine(json);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
