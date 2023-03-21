using CefBrowser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        public string html2text(string htmltext)
        {
            Regex reg1 = new Regex("<[^>]*>");
            Regex reg2 = new Regex("<style>[^<]*</style>");
            htmltext = reg2.Replace(htmltext, "");
            return reg1.Replace(htmltext, "");
        }

        public string Get_Server_Port(string mail)
        {
            int pos = mail.IndexOf("@");
            string domain = mail.Substring(pos);
            //string result = Program.g_setting.MailServer_Info[domain];
            string result = "";

            return result;
        }

        private string get_mail_store_relative_path(string mail_folder, DateTime date)
        {
            string rel_path = "";
            string parent_path = Path.Combine("Messages", m_emailaddr);
                                              
            parent_path = Path.Combine(parent_path, mail_folder);
            parent_path = Path.Combine(parent_path, date.ToString("yyyy-MM-dd"));

            int i = 1;
            while (true)
            {
                rel_path = Path.Combine(parent_path, i.ToString());
                if (!Directory.Exists(rel_path))
                    break;
                i++;
            }
            return rel_path;
        }

        private string get_mail_store_absolute_path(string mail_folder, DateTime date)
        {
            string rel_path = get_mail_store_relative_path(mail_folder, date);
            return get_mail_store_absolute_path(rel_path);
        }
        private string get_mail_store_absolute_path(string rel_path)
        {
            string path = Path.Combine(Program.g_working_directory, rel_path);
            return path;
        }

        private string get_mail_size(string path)
        {
            string size = "NONE";
            try
            {
                FileInfo fi = new FileInfo(path);
                size = String.Format("{0:00.00}", (double)fi.Length / 1024) + " KB";
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return size;
        }

        private string remove_first_end_space(string input)
        {
            if (input == null || input == string.Empty)
                return input;

            while(true)
            {
                if (input[0] != ' ')
                    break;
                else
                    input = input.Remove(0, 1);
            }

            while (true)
            {
                if (input[input.Length - 1] != ' ')
                    break;
                else
                    input = input.Remove(input.Length - 1, 1);
            }
            return input;
        }
    }
}
