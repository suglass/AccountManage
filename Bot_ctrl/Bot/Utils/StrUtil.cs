using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    public static class StrUtil
    {
        public static bool AnalyzeProxy(string _proxy, out string ip, out string port, out string login, out string pass)
        {
            ip = string.Empty;
            port = string.Empty;
            login = string.Empty;
            pass = string.Empty;

            int length = _proxy.Split(':').Length;
            if (length == 2)
            {
                Regex regex = new Regex("(.*):(.*)");
                string host = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[1].Value;
                string s = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[2].Value;
                if (host != "" && host != null && s != "" && s != null)
                {
                    ip = host;
                    port = s;
                }
                return true;
            }
            else if (length == 4)
            {
                Regex regex = new Regex("(.*):(.*):(.*):(.*)");
                string host = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[1].Value;
                string s = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[2].Value;
                string username = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[3].Value;
                string password = regex.Match(_proxy.Replace(" ", string.Empty)).Groups[4].Value;
                if (host != "" && host != null && s != "" && s != null)
                {
                    ip = host;
                    port = s;
                    login = username;
                    pass = password;
                }
                return true;
            }
            else
                return false;
        }
    }
}
