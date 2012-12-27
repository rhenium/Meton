using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using Meton.Liegen.DataModels;
using Meton.Liegen.Method.Rest;

namespace Meton.Models
{
    public class Model : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        public IObservable<Status> Update(string text)
        {
            var account = Settings.Settings.Instance.Accounts[0];
            return Tweets.Update(account.Info, text);
        }
    }
}
