using CefBrowser;
using MailKit.Net.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        public int connect()
        {
            int return_value = ConstEnv.CONNECT_FAILED;
            try
            {
                Program.log_info($"Mail server connecting.... server = {m_host}, port = {m_port}, user = {m_emailaddr}");

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(m_host, m_port, MailKit.Security.SecureSocketOptions.Auto);
                return_value = ConstEnv.CONNECT_SERVER_CON_SUCCESS;
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(m_emailaddr, m_emailpass);
                return_value = ConstEnv.CONNECT_LOGIN_SUCCESS;

                Program.log_info("Mail server connected.");
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return return_value;
        }
                
        public bool disconnect()
        {
            try
            {
                client.Disconnect(true);
                Program.log_info($"disconnected : server = {m_emailaddr}");
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                return false;
            }
            return true;
        }        
    }
}
