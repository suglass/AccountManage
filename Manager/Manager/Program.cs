using DbHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Manager
{
    static class Program
    {
        public static System.Object g_locker = new object();
        public static MainFrm g_main_frm = null;
        public static string g_full_log = "";
        public static bool g_show_log_frm = false;
        public static string g_working_directory = "";
        //public static bool g_must_end = false;
        public static string g_db_user = "";
        public static string g_db_pass = "";
        public static InstDbHelper g_db;
        public static DbConnection g_db_connection;
        public static UserSetting g_setting = new UserSetting();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            g_setting = UserSetting.Load();
            if (g_setting == null)
                g_setting = new UserSetting();

            string temp_user = string.Empty;
            string temp_pass = string.Empty;
            if (File.Exists(ConstEnv.PATH_KEY))
            {
                FileCipher.DecryptFile(ConstEnv.PATH_KEY, ConstEnv.PATH_TEMP);
                string decrypted = StringCipher.Decrypt(File.ReadAllText(ConstEnv.PATH_TEMP), "suglass");
                File.Delete(ConstEnv.PATH_TEMP);
                string[] vals = decrypted.Split('\n');
                temp_user = vals[0];
                temp_pass = vals[1];
            }

            g_db_user = "root";
            g_db_pass = "";

            bool is_all_done = false;
            while (true)
            {
                try
                {
                    g_db_connection = new DbConnection(g_setting.inst_db_name, g_setting.inst_db_host, g_setting.inst_db_port, g_db_user, g_db_pass);
                    g_db_connection.Open();
                    if (g_db_connection.is_opened)
                    {
                        g_db = new InstDbHelper(g_db_connection);
                        break;
                    }
                }
                catch (Exception exception)
                {
                    log_error($"Can not start program. Make sure MySQL server information or if it is running.\nMessage : {exception.Message}");
                }

                if (is_all_done == false && temp_user != string.Empty)
                {
                    g_db_user = temp_user;
                    g_db_pass = temp_pass;
                    is_all_done = true;
                    continue;
                }

                MessageBox.Show("Can not start program. Make sure MySQL server information or if it is running.", "DB Settings");
                Environment.Exit(0);
            }

            g_working_directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //string input = Microsoft.VisualBasic.Interaction.InputBox("Password", "Input password", "Default", -1, -1);

            g_main_frm = new MainFrm();
            Application.Run(g_main_frm);
        }

        public static void log(string msg, string logtype, bool msgbox = false)
        {
            lock (g_locker)
            {
                try
                {
                    msg = DateTime.Now.ToString("dd.MM.yyyy_hh:mm:ss ") + msg;
                    g_main_frm.log(msg, logtype);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public static void log_info(string msg, bool msgbox = false)
        {
            log(msg, "info", msgbox);
        }

        public static void log_error(string msg, bool msgbox = false)
        {
            log(msg, "error", msgbox);
        }
        public static void log_todo(string msg)
        {
            log(msg, "todo", false);
        }
    }
}
