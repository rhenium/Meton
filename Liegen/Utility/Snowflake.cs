using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meton.Liegen.Utility
{
    public class Snowflake
    {
        public static DateTime StatusIdToDateTime(long statusId)
        {
            return new DateTime(10000 * ((statusId >> 22) + 1288834974657) + new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks);
        }
    }
}
