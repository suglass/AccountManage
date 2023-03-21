using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bot
{
    public static class ConstEnv
    {
        public static readonly string inst_db_account_table_name = "accounts";
        public static readonly string inst_db_group_table_name = "group";
        public static readonly string inst_db_proxy_table_name = "proxy";
        public static readonly string inst_db_user_agent_table_name = "user_agent";
        public static readonly string inst_db_mail_server_table_name = "mail_server";
        public static readonly string inst_db_user_table_name = "users";

        public static readonly int CONNECT_FAILED = 0;
        public static readonly int CONNECT_SERVER_CON_SUCCESS = 1;
        public static readonly int CONNECT_LOGIN_SUCCESS = 2;

        public static readonly int SEARCH_ERROR = 3;
        public static readonly int SEARCH_SUCCESS = 4;

        public static readonly string PATH_MAILS = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Messages");
        public static readonly string PATH_CACHE = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CefCache");
        public static readonly string PATH_KEY = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "base.dat");
        public static readonly string PATH_TEMP = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "base0.dat");

        public static readonly int PROXY_TYPE_HTTPS = 0;
        public static readonly int PROXY_TYPE_SOCKS4 = 1;
        public static readonly int PROXY_TYPE_SOCKS5 = 2;

        public static readonly int LOGIN_STARTED = 0;
        public static readonly int LOGIN_SUCCESS = 1;

        public static readonly int VERIFY_NoUser = 0;
        public static readonly int VERIFY_InvalidPass = 1;
        public static readonly int VERIFY_SUCCESS = 2;
    }
}
