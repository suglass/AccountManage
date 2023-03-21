using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CefBrowser
{
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.ini";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Saving Failed : " + e.Message);
            }
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                T t = new T();
                if (File.Exists(fileName))
                    t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
                else
                    return default(T);
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Loading Failed : " + e.Message);
                return default(T);
            }
        }
    }

    public class UserSetting : AppSettings<UserSetting>
    {
        public string inst_db_name = "db_instbot";
        public string inst_db_host = "localhost";
        public int inst_db_port = 3306;
    }
}
