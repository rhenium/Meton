using System.Net;

namespace Meton.Liegen.Net
{
    public static class NetworkSetting
    {
        static NetworkSetting()
        {
            UserAgent = "Liegen/" + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;
            Proxy = WebRequest.GetSystemWebProxy();
            Timeout = System.Threading.Timeout.Infinite;
        }

        public static string UserAgent { get; set; }

        public static IWebProxy Proxy { get; set; }

        public static int Timeout { get; set; }
    }
}
