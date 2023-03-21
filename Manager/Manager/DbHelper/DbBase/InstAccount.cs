using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHelper.DbBase
{
    public class InstAccount
    {
        public int id;
        public string username;
        public string userpass;
        public string emailaddr;
        public string emailpass;
        public string proxy;
        public string deviceid;
        public string user_agent;
        public string uuid;
        public string screensize;
        public string group_name;

        public InstAccount()
        {
            id = 0;
            username = "";
            emailpass = "";
            emailaddr = "";
            emailpass = "";
            proxy = "";
            deviceid = "";
            user_agent = "";
            uuid = "";
            screensize = "";
            group_name = "";
        }
    }
}
