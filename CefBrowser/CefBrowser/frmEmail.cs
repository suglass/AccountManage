using BaseModule;
using CefSharp;
using DbHelper.DbBase;
using MailHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefBrowser
{
    public partial class frmEmail : Form
    {
        public InstAccount m_acc;
        public List<SearchResult> m_lst_search_res;
        private static int m_cef_count = 0;

        public frmEmail(int _acc_id)
        {
            InitializeComponent();
            m_cef_count++;

            m_acc = Program.g_db.GetAccountById(_acc_id);
            prgbar.Visible = false;
            prgbar.Style = ProgressBarStyle.Marquee;
            prgbar.MarqueeAnimationSpeed = 30;
            m_lst_search_res = new List<SearchResult>();

            lvSearchResult.Columns.Add("No");
            lvSearchResult.Columns.Add("Subject");
            lvSearchResult.Columns.Add("From");
            lvSearchResult.Columns.Add("To");

            //lvSearchResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvSearchResult.Columns[0].Width = 30;
            lvSearchResult.Columns[1].Width = lvSearchResult.Size.Width / 3 - 30;
            lvSearchResult.Columns[2].Width = lvSearchResult.Size.Width / 3 - 2;
            lvSearchResult.Columns[3].Width = lvSearchResult.Size.Width / 3 - 2;

            this.Text += " (" + m_acc.username + ")";
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            DeleteMails();
            await LoadMail();
        }

        private async Task LoadMail()
        {
            bool is_thread_finished = false;

            Invoke(new Action(() =>
            {
                prgbar.Visible = true;
            }));

            new Thread((ThreadStart)(() =>
            {
                FetchMails();
                is_thread_finished = true;
            })).Start();

            await Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    if (is_thread_finished)
                    {
                        Invoke(new Action(() =>
                        {
                            prgbar.Visible = false;
                        }));
                        break;
                    }
                }
            });
            ShowResults();
        }

        private void FetchMails()
        {
            string host = string.Empty;
            int port = 0;

            Program.g_db.GetMailServerFromAccId(m_acc.id, out host, out port);

            if (host == string.Empty || port == 0)
            {
                Program.log_error($"Invalid mail server - {host} - {port}. Addr -{m_acc.emailaddr}");
                return;
            }

            MailChecker mail_checker = new MailChecker(host, port, m_acc.emailaddr, m_acc.emailpass);
            int ret = mail_checker.Search(out m_lst_search_res);
            SortSearchResult();
        }

        private void SortSearchResult()
        {
            for (int i = 0; i < m_lst_search_res.Count - 1; i++)
                for (int j = i + 1; j < m_lst_search_res.Count; j++)
                {
                    if (m_lst_search_res[i].dtReceived < m_lst_search_res[j].dtReceived)
                    {
                        SearchResult temp = new SearchResult(m_lst_search_res[i]);
                        m_lst_search_res[i] = new SearchResult(m_lst_search_res[j]);
                        m_lst_search_res[j] = new SearchResult(temp);
                    }
                }
        }

        private void ShowResults()
        {
            int idx_from = 0;
            int idx_to = m_lst_search_res.Count;

            Invoke(new Action(() =>
            {
                lvSearchResult.Items.Clear();
                lvSearchResult.Refresh();
                for (int i = idx_from; i < idx_to; i++)
                {
                    SearchResult item = m_lst_search_res[i];

                    ListViewItem lvI = new ListViewItem((i + 1).ToString());
                    lvI.SubItems.Add(item.strSubject);
                    lvI.SubItems.Add(item.strFrom);
                    lvI.SubItems.Add(item.strTo);

                    lvSearchResult.Items.Add(lvI);
                }
                //lvSearchResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }));
        }
        private void lvSearchResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvSearchResult.FocusedItem != null && lvSearchResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    SelectAction(sender, e);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (lvSearchResult.FocusedItem != null && lvSearchResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu m = new ContextMenu();

                    MenuItem infoMenuItem = new MenuItem("Get Date");
                    infoMenuItem.Click += delegate (object sender2, EventArgs e2)
                    {
                        DateAction(sender, e);
                    };// your action here 
                    m.MenuItems.Add(infoMenuItem);

                    m.Show(lvSearchResult, new Point(e.X, e.Y));
                }
            }
        }

        private void SelectAction(object sender, MouseEventArgs e)
        {
            //id is extra value when you need or delete it
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;
            int id = ListViewControl.SelectedItems[0].Index;
            //int id = int.Parse(ListViewControl.SelectedItems[0].SubItems[0].Text) - 1;

            string eml_path = m_lst_search_res[id].strEmlPath;
            string mail_content = MailChecker.get_mail_content_from_mimemessage(eml_path);

            webroMail.Load("dummy:");
            webroMail.LoadHtml(mail_content, "dummy:");
        }
        private void DateAction(object sender, MouseEventArgs e)
        {
            //id is extra value when you need or delete it
            ListView ListViewControl = sender as ListView;

            if (ListViewControl.SelectedItems.Count > 1)
                return;
            int id = ListViewControl.SelectedItems[0].Index;

            string date = m_lst_search_res[id].dtReceived.ToString();
            MessageBox.Show(date);
        }


        private void lvSearchResult_Resize(object sender, EventArgs e)
        {
            lvSearchResult.Columns[0].Width = 30;
            lvSearchResult.Columns[1].Width = lvSearchResult.Size.Width / 3 - 30;
            lvSearchResult.Columns[2].Width = lvSearchResult.Size.Width / 3 - 2;
            lvSearchResult.Columns[3].Width = lvSearchResult.Size.Width / 3 - 2;
            btnLoad.Location = new System.Drawing.Point(lvSearchResult.Size.Width - 116, 11);
        }

        private void frmEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_cef_count--;
            
            /*if (m_cef_count == 0)
                Cef.Shutdown();*/
        }

        private void DeleteMails()
        {
            try
            {
                string curr_path = Path.Combine("Messages", m_acc.emailaddr);

                /*foreach (string line in Directory.GetFiles(curr_path))
                    File.Delete(line);
                foreach (string line in Directory.GetDirectories(curr_path))
                    Directory.Delete(line, true);*/
                Directory.Delete(curr_path, true);

            }
            catch(Exception exception)
            {

            }
        }

        private void frmEmail_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteMails();
        }
    }
}
