using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using CefBrowser;

namespace MailHelper
{
    public partial class MailChecker
    {
        public ImapClient client = new ImapClient();

        public string m_host;
        public int m_port;

        public string m_emailaddr;
        public string m_emailpass;

        public int m_thread_num;

        public bool is_search_finished;

        public MailChecker(string _host, int _port, string _addr, string _pass)
        {
            is_search_finished = false;

            m_host = _host;
            m_port = _port;
            m_emailaddr = _addr;
            m_emailpass = _pass;
        }
        public int try_connect()
        {
            int output = connect();

            if (output >= ConstEnv.CONNECT_SERVER_CON_SUCCESS)
                disconnect();

            return output;
        }
    }
}
