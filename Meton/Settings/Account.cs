using Meton.Liegen;
using Meton.Liegen.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meton.Settings
{
    public class Account
    {
        public AccountInfo Info { get; set; }
        public long UserId { get; set; }
        public string ScreenName { get; set; }
        public bool UserStreams { get; set; }

        public Account(AccountInfo info, long userId, string screenName, bool userStreams)
        {
            this.Info = info;
            this.UserId = userId;
            this.ScreenName = screenName;
            this.UserStreams = userStreams;
        }

    }
}
