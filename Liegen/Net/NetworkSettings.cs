using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http.Headers;

namespace Meton.Liegen.Net
{
    public static class NetworkSettings
    {
        static NetworkSettings()
        {
            UserAgent = "Liegen/" + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;
            Proxy = null;
            Timeout = System.Threading.Timeout.InfiniteTimeSpan;
            OptionRequestHeaders = new Dictionary<string, string>();
        }

        public static string UserAgent { get; set; }

        public static IWebProxy Proxy { get; set; }

        public static TimeSpan Timeout { get; set; }

        public static Dictionary<string, string> OptionRequestHeaders { get; set; }

        internal static IEnumerable<KeyValuePair<string, string>> GetOptionRequestHeaders
        {
            get
            {
                return new[] { new KeyValuePair<string, string>("User-Agent", NetworkSettings.UserAgent) }.Concat(NetworkSettings.OptionRequestHeaders);
            }
        }
    }
}
