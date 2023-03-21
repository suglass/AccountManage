using BaseModule;
using CefBrowser;
using MailKit;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        private string get_sender_from_mimemessage(MimeMessage message)
        {
            string sender = "";

            if (message.Sender != null)
            {
                sender = message.Sender.Address;
            }
            else if (message.From != null)
            {
                foreach (MailboxAddress from in message.From)
                {
                    if (sender == "")
                        sender = from.Address;
                    else
                        sender = sender + "|" + from.Address;
                }
            }
            return sender;
        }
        private string get_sender_name_from_mimemessage(MimeMessage message)
        {
            string name = "";
            if (message.Sender != null)
            {
                name = message.Sender.Name;
            }
            else if (message.From != null)
            {
                foreach (MailboxAddress from in message.From)
                {
                    if (name == "")
                        name = from.Name;
                    else
                        name += "|" + from.Name;
                }
            }
            return name;
        }

        private string get_To_from_mimemessage(MimeMessage message)
        {
            string sender = "";

            if (message.To != null)
            {
                sender = message.To.ToString();
            }
            return sender;
        }
        /*private string get_receiver_name_from_mimemessage(MimeMessage message)
        {
            string name = "";
            if (message.Sender != null)
            {
                name = message.Sender.Name;
            }
            else if (message.From != null)
            {
                foreach (MailboxAddress from in message.From)
                {
                    if (name == "")
                        name = from.Name;
                    else
                        name += "|" + from.Name;
                }
            }
            return name;
        }*/
        public static string get_mail_content_from_mimemessage(string eml_path)
        {
            MimeMessage message = MimeMessage.Load(eml_path);

            /*string content = "";
            if (message.Sender != null)
                content = "From - " + message.Sender.ToString();
            else if (message.From != null)
                content = "From - " + message.From.ToString();

            content += "\n" + "To - " + message.To.ToString();
            content += "\n" + "Subject - " + message.Subject;
            content += "\n" + "Date - " + DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss")).ToString();
            content += "\n" + "Body - " + "\n";
            content += "\n" + message.TextBody;*/
            return message.HtmlBody;
        }

        private List<FetchParam> get_FetchParamList_retry(SearchQuery in_query)
        {
            int idx_nss = 0;
            int idx_ns = 0;
            int idx_box = 0;

            List<FetchParam> paramlist = new List<FetchParam>();

            FolderNamespaceCollection[] ns_lists = new FolderNamespaceCollection[]
            {
                client.PersonalNamespaces,
                client.SharedNamespaces,
                client.OtherNamespaces
            };

            Program.log_info($"Start getting fetch params : {m_emailaddr}");

            while (true)
            {
                try
                {
                    int count_nss = ns_lists.Length;
                    while (idx_nss < count_nss)
                    {
                        var nss = ns_lists[idx_nss];
                        int count_ns = nss.Count;

                        while (idx_ns < count_ns)
                        {
                            var ns = nss[idx_ns];
                            var boxes = client.GetFolders(ns);
                            int count_box = boxes.Count;

                            while (idx_box < count_box)
                            {
                                IMailFolder box = boxes[idx_box];

                                box.Subscribe();
                                box.Open(FolderAccess.ReadOnly);

                                var ret = box.Search(in_query);

                                string strBoxName = box.FullName;
                                //int recnum = box.Count;
                                int recnum = ret.Count;

                                if (recnum > 0)
                                {
                                    foreach (var uid in ret)
                                    {
                                        FetchParam mid = new FetchParam(strBoxName, uid);

                                        paramlist.Add(mid);
                                    }
                                }

                                idx_box++;
                            }
                            idx_ns++;
                        }
                        idx_nss++;
                    }
                    break;
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    if (!client.IsConnected)
                        connect();
                    else
                    {
                        Program.log_error("SUGH.");
                        break;
                    }
                }
            }

            Program.log_info($"End getting fetch params : {m_emailaddr}. Params num = {paramlist.Count}");

            return paramlist;
        }

        private List<FetchParam> get_FetchParamList_retry(string path, SearchQuery in_query)
        {
            int idx = 0;
            List<FetchParam> paramlist = new List<FetchParam>();

            Program.log_info($"Start getting fetch params : {m_emailaddr}");

            while (true)
            {
                try
                {
                    IMailFolder box = client.GetFolder(path);
                    box.Subscribe();
                    box.Open(FolderAccess.ReadOnly);

                    var ret = box.Search(in_query);

                    string strBoxName = box.FullName;
                    int recnum = ret.Count;

                    if (recnum > 0)
                    {
                        while (idx < recnum)
                        {
                            var uid = ret[idx];
                            FetchParam mid = new FetchParam(strBoxName, uid);

                            paramlist.Add(mid);
                            idx++;
                        }
                    }
                    break;
                }
                catch (Exception exception)
                {
                    Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    if (!client.IsConnected)
                        connect();
                    else
                    {
                        Program.log_error("SUGH.");
                        break;
                    }
                }
            }
            Program.log_info($"End getting fetch params : {m_emailaddr}. Params num = {paramlist.Count}");
            return paramlist;
        }
    }
}
