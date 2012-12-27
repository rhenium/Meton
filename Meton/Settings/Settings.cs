using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Livet;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace Meton.Settings
{
    public class Settings : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        private static readonly string SettingsFileName =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Settings.xml";

        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        var xsz = new XmlSerializer(typeof(Settings));
                        using (var fs = new FileStream(SettingsFileName, FileMode.Open, FileAccess.Read))
                        {
                            _instance = (Settings)xsz.Deserialize(fs);
                        }
                    }
                    catch
                    {
                        _instance = new Settings();
                    }
                }
                
                return _instance;
            }
        }

        public void Save()
        {
            var xsz = new XmlSerializer(typeof(Settings));
            using (var fs = new FileStream(SettingsFileName, FileMode.Create, FileAccess.Write))
            {
                xsz.Serialize(fs, this);
            }
        }

        public List<Account> Accounts { get; set; }
    }
}
