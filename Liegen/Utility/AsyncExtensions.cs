using System;
using System.IO;
using System.Net;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;

namespace Meton.Liegen.Utility
{
    public static class WebRequestExtensions
    {
        public static IObservable<WebResponse> GetResponseAsObservable(this WebRequest request)
        {
            return request.GetResponseAsync().ToObservable()
                .Catch((WebException ex) => Observable.Return(ex.Response));
        }

        public static IObservable<WebResponse> GetResponseAsObservable(this WebRequest request, byte[] data)
        {
            return Observable.Using(() => request.GetRequestStream(), stream => stream.WriteAsync(data, 0, data.Length).ToObservable())
                .SelectMany(_ => request.GetResponseAsObservable());
        }
    }

    public static class WebResponseExtensions
    {
        [Obsolete]
        public static IObservable<string> DownloadStringAsObservable(this WebResponse response)
        {
            return Observable.Defer(() => new StreamReader(response.GetResponseStream()).ReadToEndAsync().ToObservable());
        }

        public static IObservable<string> DownloadStringAsObservable(this IObservable<WebResponse> response)
        {
            return response.Select(res => res.GetResponseStream())
                .SelectMany(stream => new StreamReader(stream).ReadToEndAsync());
        }

        public static IObservable<string> DownloadStringLineAsObservable(this IObservable<WebResponse> response)
        {
            return response.Select(res => res.GetResponseStream())
                .Select(stream => new StreamReader(stream))
                .SelectMany(streamReader => streamReader.ReadLineAsync());
        }
    }
}