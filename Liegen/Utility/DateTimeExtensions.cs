using System;
using System.Globalization;

namespace Meton.Liegen.Utility
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixEpochTimeByDateTime(this DateTime value)
        {
            return (long)(value - unixEpoch).TotalSeconds;
        }

        public static DateTime GetDateTimeByUnixEpochTime(this long value)
        {
            return unixEpoch.AddSeconds(value);
        }

        public static DateTime ParseDateTime(this string value)
        {
            string[] formats = {
                "ddd MMM dd HH:mm:ss zzzz yyyy",
                "ddd, d MMM yyyy HH:mm:ss zzzz"
            };
            foreach (var format in formats)
            {
                DateTime result;
                if (DateTime.TryParseExact(value, format, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out result))
                {
                    return result;
                }
            }
            throw new ArgumentException("Can't parse string as DateTime.");
        }
    }
}
