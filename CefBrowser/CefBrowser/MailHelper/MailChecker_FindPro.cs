using BaseModule;
using CefBrowser;
using MailKit;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailHelper
{
    partial class MailChecker
    {
        public int Search(out List<SearchResult> lst_search_res)
        {
            lst_search_res = new List<SearchResult>();

            try
            {
                int w_return_value = connect();

                if (w_return_value != ConstEnv.CONNECT_LOGIN_SUCCESS)
                    return w_return_value;

                List<FetchParam> w_fetch_param_list = get_FetchParamList();

                Program.log_info($"Fetch param list count - {w_fetch_param_list.Count}");

                if (w_fetch_param_list.Count == 0)
                    return ConstEnv.SEARCH_SUCCESS;

                /*Program.g_prog_total = w_fetch_param_list.Count;
                Program.g_prog_current = 0;*/

                //int w_threads_num = (w_fetch_param_list.Count - 1) / Program.g_setting.SEARCH_MAILS_NUM_PER_THREAD + 1;
                int w_threads_num = 1;

                lst_search_res = SearchWorkFlow(w_fetch_param_list, w_threads_num);

                if (client.IsConnected)
                    disconnect();

                is_search_finished = true;
                return ConstEnv.SEARCH_SUCCESS;
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}.");
                return ConstEnv.SEARCH_ERROR;
            }
        }

        public List<SearchResult> SearchWorkFlow(List<FetchParam> _fetch_param_list, int in_thread_num)
        {
            List<SearchResult> lst_search_result = new List<SearchResult>();

            foreach(FetchParam param in _fetch_param_list)
            {
                IMailFolder w_mail_box = client.GetFolder(param.folder_path);
                Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} mail box is got.");

                if (!w_mail_box.IsOpen)
                {
                    w_mail_box.Subscribe();
                    w_mail_box.Open(FolderAccess.ReadOnly);
                }

                Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} mailbox is opened.");
                MimeMessage message = w_mail_box.GetMessage(param.idx_mail);
                SearchResult search_result = get_item_result(message, param.folder_path, param.idx_mail);
                lst_search_result.Add(search_result);
            }
            Program.log_info("SearchWorkFlow finished.");
            return lst_search_result;
        }

        public List<FetchParam> get_FetchParamList()
        {
            List<FetchParam> w_output_list = new List<FetchParam>();

            try
            {
                Program.log_info($"Start fetch_mails : user = {m_emailaddr}");

                DateTime today = DateTime.Today;

                /*DateTime after = today.Date - new TimeSpan(1, 0, 0, 0);
                DateTime before = today.Date + new TimeSpan(1, 0, 0, 0);
                SearchQuery search_query = SearchQuery.SentSince(after).And(SearchQuery.SentBefore(before));*/

                w_output_list.AddRange(get_FetchParamList_retry("INBOX", SearchQuery.All));

                /*bool w_is_duplicated = check_FetchParamList_duplicated(w_output_list);
                if (w_is_duplicated)
                    Program.log_info($"Fetch param list is duplicated. User = {m_account.mail_address}");*/
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message} - SUGH");
            }

            return w_output_list;
        }

        private SearchResult get_item_result(MimeMessage message, string path, UniqueId id)
        {
            Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} started. {path} - {id.ToString()}");

            SearchResult result_item = new SearchResult();

            string subject = message.Subject == null ? string.Empty : message.Subject;
            string body = message.TextBody == null ? string.Empty : message.TextBody;

            Program.log_info($"{System.Reflection.MethodBase.GetCurrentMethod().Name} body and subject checked.");

            string sender = get_sender_from_mimemessage(message);
            DateTime date = DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            string sender_name = get_sender_name_from_mimemessage(message);

            /*if (sender == m_account.mail_address)
                continue;*/

            result_item.strSubject = subject;
            result_item.strFrom = "\"" + sender_name + "\"" + "<" + sender + ">";
            result_item.dtReceived = DateTime.Parse(message.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            result_item.strTo = get_To_from_mimemessage(message);

            string rel_path = get_mail_store_relative_path(path, date);
            Directory.CreateDirectory(rel_path);

            string eml_path = Path.Combine(rel_path, $"message_{id.ToString()}.eml");
            message.WriteTo(eml_path);

            result_item.strEmlPath = eml_path;

            /*lock (Program.g_search_result)
            {
                Program.g_search_result.Add(result_item);
            }*/

            Program.log_info($"{eml_path} finished.");
            return result_item;
        }

        private bool check_FetchParamList_duplicated(List<FetchParam> in_list)
        {
            if (in_list == null || in_list.Count == 0)
                return false;

            while (in_list.Count > 0)
            {
                FetchParam param = in_list[0];
                in_list.RemoveAt(0);

                if (in_list.Contains(param))
                    return true;
            }
            return false;
        }

        private bool check_key_contains(string in_content, List<string> in_lstrKeys)
        {
            bool is_contained = false;
            bool is_all_blank = true;

            if (in_lstrKeys == null || in_lstrKeys.Count == 0 || in_lstrKeys[0].Replace(" ", "") == "" && in_lstrKeys.Count == 1)
                return true;

            foreach (string key in in_lstrKeys)
            {
                if (key.Replace(" ", "") == string.Empty)
                    continue;

                if (key == null || key == string.Empty)
                    continue;

                is_all_blank = false;

                string temp = remove_first_end_space(key);

                if (in_content.IndexOf(temp, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    is_contained = true;
                    break;
                }
            }
            if (is_all_blank)
                return true;
            return is_contained;
        }
    }
}
