using Meton.Liegen.Utility;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Meton.Liegen.Net
{
    public static class HttpUtility
    {
        private const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        // 参考: http://watcher.moe-nifty.com/memo/2009/04/c-oauth-c097.html
        public static string UrlEncode(this string value, bool upper = true)
        {
            StringBuilder result = new StringBuilder();
            byte[] data = Encoding.UTF8.GetBytes(value);
            int len = data.Length;

            for (int i = 0; i < len; i++)
            {
                int c = data[i];
                if (c < 0x80 && unreservedChars.IndexOf((char)c) != -1)
                {
                    result.Append((char)c);
                }
                else
                {
                    if (upper)
                    {
                        result.Append('%' + String.Format("{0:X2}", (int)data[i]));
                    }
                    else
                    {
                        result.Append('%' + String.Format("{0:x2}", (int)data[i]));
                    }
                }
            }
            return result.ToString();
        }

        public static string UrlDecode(this string value)
        {
            return Uri.UnescapeDataString(value);
        }
    }
}