using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using DbHelper.DbBase;

namespace CefBrowser
{
    public partial class frmCefBrowser : Form
    {
        public int m_id;
        public InstAccount m_acc;

        public ChromiumWebBrowser m_CefBrowser;

        public frmCefBrowser()
        {
            InitializeComponent();

            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 2)
            {
                m_id = int.Parse(args[1]);

                m_acc = Program.g_db.GetAccountById(m_id);
                string str_chr_data_path = m_id.ToString();

                string user_agent = Program.g_db.GetUserAgentFromAccId(m_id);
                if (user_agent == string.Empty)
                {
                    user_agent = Program.g_db.SetRandomUserAgentToAcc(m_id);
                }

                string proxy = Program.g_db.GetProxyFromAccId(m_id);

                string converter_path = $"CefBrowser.exe";

                string w_str_ip = string.Empty;
                string w_str_port = string.Empty;
                string w_str_proxy_login = string.Empty;
                string w_str_proxy_pass = string.Empty;
                AnalyzeProxy(proxy, out w_str_ip, out w_str_port, out w_str_proxy_login, out w_str_proxy_pass);

                str_chr_data_path = Path.Combine(ConstEnv.PATH_CACHE, str_chr_data_path);

                CefSettings cefsetting = new CefSettings();
                CefSharpSettings.Proxy = new ProxyOptions(ip: w_str_ip, port: w_str_port, username: w_str_proxy_login, password: w_str_proxy_pass);
                cefsetting.UserAgent = user_agent;
                cefsetting.CachePath = str_chr_data_path;

                cefsetting.WindowlessRenderingEnabled = true;
                cefsetting.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
                cefsetting.CefCommandLineArgs.Add("disable-gpu", "1");

                Cef.Initialize(cefsetting);

                m_CefBrowser = new CefSharp.WinForms.ChromiumWebBrowser("")
                {
                    Dock = DockStyle.Fill,
                };
                this.m_CefBrowser.AddressChanged += Browser_AddressChanged;
                m_CefBrowser.LoadingStateChanged += Browser_LoadingStateChaged;
                m_CefBrowser.FrameLoadEnd += Browser_FrameLoadEnded;

                panel3.Controls.Add(m_CefBrowser);

                this.Text += " (" + m_acc.username + ")";
            }
            else
            {
                MessageBox.Show("Invalid arguments.");
            }
            Navigate("https://www.google.com/");
            txt_url.Text = "https://www.google.com/";
        }

        private void Browser_FrameLoadEnded(object sender, FrameLoadEndEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                progressBar1.Visible = false;
            });
        }

        private void Browser_LoadingStateChaged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading)
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    progressBar1.Visible = true;
                });
            }
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                txt_url.Text = e.Address;
            });
        }

        private void Navigate(string url)
        {
            m_CefBrowser.Load(url);
        }

        private void btnNavigate_Click(object sender, EventArgs e)
        {
            Navigate(txt_url.Text);
        }

        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(txt_url.Text);
            }
        }

        private void frmBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(m_acc.username);
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(m_acc.userpass);
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            Navigate("https://instagram.com");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            m_CefBrowser.Back();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //m_CefBrowser.Refresh();
            if (m_CefBrowser.IsLoading)
                m_CefBrowser.Stop(); //Stops loading the current page.
            m_CefBrowser.Reload();
        }

        public bool AnalyzeProxy(string _proxy, out string ip, out string port, out string login, out string pass)
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

        private void btnEmail_Click(object sender, EventArgs e)
        {
            int mail_server_id = Program.g_db.GetMailServerTbIdFromId(m_acc.id);
            if (mail_server_id == -1)
            {
                MessageBox.Show("This account has no mail.");
                return;
            }

            frmEmail dlg = new frmEmail(m_acc.id);
            dlg.Show();
        }

        public void log(string msg, string logtype)
        {
            txt_last_log.Text = msg;
            /*Program.g_full_log += "\n" + msg;
            if (Program.g_log_frm != null)
                Program.g_log_frm.update_log();*/
        }
    }
}
