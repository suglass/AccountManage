using Manager;
using DbHelper.DbBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DbHelper
{
    public class InstDbHelper : DbBaseHelper
    {
        public InstDbHelper(DbConnection p_connection) : base(p_connection)
        {

        }

        public List<List<InstAccount>> GetAllAccounts(int _user_id)
        {
            List<List<InstAccount>> lst_accs = new List<List<InstAccount>>();
            try
            {
                List<string> lstr_group_names = GetGroupNames(_user_id);

                foreach (string group_name in lstr_group_names)
                {
                    List<InstAccount> lst_accounts = GetAccountsByGroup(group_name, _user_id);
                    lst_accs.Add(lst_accounts);
                }
                return lst_accs;
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return null;
        }

        public List<string> GetGroupNames(int _user_id)
        {
            List<string> lstr_group_names = new List<string>();
            DataTable dt = select("SELECT group_name FROM `{0}` WHERE user_id = '{1}';", ConstEnv.inst_db_group_table_name, _user_id);
            foreach (DataRow row in dt.Rows)
                lstr_group_names.Add(row["group_name"].ToString());
            return lstr_group_names;
        }

        public List<InstAccount> GetAccountsByGroup(string group_name, int _user_id)
        {
            List<InstAccount> lst_accounts = new List<InstAccount>();

            DataTable dt = select("SELECT accounts.id, accounts.username, accounts.userpass, accounts.emailaddr," +
                " accounts.emailpass, proxy.proxy, accounts.deviceid, user_agent.user_agent, accounts.uuid, " +
                "accounts.screensize FROM `{3}` LEFT JOIN `{0}` ON accounts.group_id = group.id " +
                "LEFT JOIN `{1}` ON accounts.proxy_id = proxy.id " +
                "LEFT JOIN `{2}` ON accounts.user_agent_id = user_agent.id " +
                "WHERE `{0}`.group_name = '{4}' AND `{3}`.user_id = '{5}';", ConstEnv.inst_db_group_table_name, ConstEnv.inst_db_proxy_table_name,
                ConstEnv.inst_db_user_agent_table_name, ConstEnv.inst_db_account_table_name, group_name, _user_id);

            foreach (DataRow row in dt.Rows)
            {
                InstAccount acc = new InstAccount();
                acc.id = int.Parse(row["id"].ToString());
                acc.username = row["username"].ToString();
                acc.userpass = row["userpass"].ToString();
                acc.emailaddr = row["emailaddr"].ToString();
                acc.emailpass = row["emailpass"].ToString();
                acc.proxy = row["proxy"].ToString();
                acc.deviceid = row["deviceid"].ToString();
                acc.user_agent = row["user_agent"].ToString();
                acc.uuid = row["uuid"].ToString();
                acc.screensize = row["screensize"].ToString();
                acc.group_name = group_name;

                lst_accounts.Add(acc);
            }

            return lst_accounts;
        }

        public InstAccount GetAccountById(int id)
        {
            InstAccount acc = new InstAccount();
            DataTable dt = select("SELECT accounts.id, accounts.username, accounts.userpass, accounts.emailaddr," +
                " accounts.emailpass, proxy.proxy, accounts.deviceid, user_agent.user_agent, accounts.uuid, " +
                "accounts.screensize, `group`.group_name FROM `{3}` LEFT JOIN `{0}` ON accounts.group_id = group.id " +
                "LEFT JOIN `{1}` ON accounts.proxy_id = proxy.id " +
                "LEFT JOIN `{2}` ON accounts.user_agent_id = user_agent.id " +
                "WHERE accounts.id = '{4}';", ConstEnv.inst_db_group_table_name, ConstEnv.inst_db_proxy_table_name,
                ConstEnv.inst_db_user_agent_table_name, ConstEnv.inst_db_account_table_name, id);

            if (dt == null || dt.Rows.Count == 0)
            {
                Program.log_info($"No account on id - {id}");
                return null;
            }
            if (dt.Rows.Count >= 2)
            {
                Program.log_info($"Duplicated account on id - {id}");
                throw new Exception($"Duplicated account on id - {id}");
            }
            foreach (DataRow row in dt.Rows)
            {
                
                acc.id = int.Parse(row["id"].ToString());
                acc.username = row["username"].ToString();
                acc.userpass = row["userpass"].ToString();
                acc.emailaddr = row["emailaddr"].ToString();
                acc.emailpass = row["emailpass"].ToString();
                acc.proxy = row["proxy"].ToString();
                acc.deviceid = row["deviceid"].ToString();
                acc.user_agent = row["user_agent"].ToString();
                acc.uuid = row["uuid"].ToString();
                acc.screensize = row["screensize"].ToString();
                acc.group_name = row["group_name"].ToString();
            }
            return acc;
        }

        public string GetUserAgentFromAccId(int acc_id)
        {
            try
            {
                DataTable dt = select("SELECT user_agent.user_agent FROM `{0}` " +
                "LEFT JOIN `{1}` ON accounts.user_agent_id = user_agent.id " +
                "WHERE accounts.id = {2};", ConstEnv.inst_db_user_agent_table_name,
                ConstEnv.inst_db_account_table_name, acc_id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Program.log_info($"No user_agent on account id - {acc_id}");
                    return string.Empty;
                }
                if (dt.Rows.Count >= 2)
                {
                    Program.log_info($"Duplicated user_agent on account id - {acc_id}");
                    throw new Exception($"Duplicated user_agent on account id - {acc_id}");
                }
                foreach (DataRow row in dt.Rows)
                    return row["user_agent"].ToString();
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return string.Empty;
        }

        /*public string GetUserAgentFromId(string _id)
        {
            try
            {
                DataTable dt = select("SELECT user_agent FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_user_agent_table_name, _id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Program.log_info($"No user_agent on account id - {acc_id}");
                    return string.Empty;
                }
                if (dt.Rows.Count >= 2)
                {
                    Program.log_info($"Duplicated user_agent on account id - {acc_id}");
                    throw new Exception($"Duplicated user_agent on account id - {acc_id}");
                }
                foreach (DataRow row in dt.Rows)
                    return row["user_agent"].ToString();
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return string.Empty;
        }*/

        public string SetRandomUserAgentToAcc(int acc_id)
        {
            try
            {
                DataTable dt = select("SELECT * FROM {0} ORDER BY RAND() LIMIT 1;", ConstEnv.inst_db_user_agent_table_name);

                if (dt == null || dt.Rows.Count == 0)
                {
                    Program.log_info($"No Random User Agent.");
                    return string.Empty;
                }

                string id = dt.Rows[0]["id"].ToString();
                string user_agent = dt.Rows[0]["user_agent"].ToString();

                update("UPDATE {0} SET user_agent_id = '{2}' WHERE id = '{1}';", ConstEnv.inst_db_account_table_name, acc_id, id);
                return user_agent;
            }
            catch(Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return string.Empty;
        }

        public string GetProxyFromAccId(int acc_id)
        {
            try
            {
                DataTable dt = select("SELECT proxy.proxy FROM `{0}` " +
                "LEFT JOIN `{1}` ON accounts.proxy_id = proxy.id " +
                "WHERE accounts.id = {2};", ConstEnv.inst_db_proxy_table_name,
                ConstEnv.inst_db_account_table_name, acc_id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Program.log_info($"No proxy on account id - {acc_id}");
                    return string.Empty;
                }
                if (dt.Rows.Count >= 2)
                {
                    Program.log_info($"Duplicated proxy on account id - {acc_id}");
                    throw new Exception($"Duplicated proxy on account id - {acc_id}");
                }
                foreach (DataRow row in dt.Rows)
                    return row["proxy"].ToString();
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
            return string.Empty;
        }

        public void GetMailServerFromAccId(int acc_id, out string host, out int port)
        {
            host = string.Empty;
            port = 0;

            try
            {
                DataTable dt = select("SELECT `imap_email_host`, `port` FROM `{0}` " +
                "LEFT JOIN `{1}` ON accounts.mail_server_id = mail_server.id " +
                "WHERE accounts.id = '{2}';", ConstEnv.inst_db_mail_server_table_name,
                ConstEnv.inst_db_account_table_name, acc_id);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Program.log_info($"No mail server on account id - {acc_id}");
                    return;
                }
                if (dt.Rows.Count >= 2)
                {
                    Program.log_info($"Duplicated mail server on account id - {acc_id}");
                    throw new Exception($"Duplicated mail server on account id - {acc_id}");
                }
                foreach (DataRow row in dt.Rows)
                {
                    host = row["imap_email_host"].ToString();
                    port = int.Parse(row["port"].ToString());
                    break;
                }
            }
            catch (Exception exception)
            {
                Program.log_error($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
            }
        }

        public int GetMailServerId(string mail_server)
        {
            string host = mail_server.Split(':')[0];
            int port = int.Parse(mail_server.Split(':')[1]);

            DataTable dt = select("SELECT * FROM {0} WHERE imap_email_host = '{1}' AND port = '{2}';",
                ConstEnv.inst_db_mail_server_table_name, host, port);

            if (dt == null || dt.Rows.Count == 0)
            {
                insert("INSERT INTO {0} (imap_email_host, port) VALUES ('{1}', '{2}');", ConstEnv.inst_db_mail_server_table_name, host, port);
                dt = select("SELECT * FROM {0} WHERE imap_email_host = '{1}' AND port = '{2}';",
                ConstEnv.inst_db_mail_server_table_name, host, port);
            }
            return int.Parse(dt.Rows[0]["id"].ToString());
        }

        public int GetProxyId(string _proxy)
        {
            DataTable dt = select("SELECT * FROM {0} WHERE proxy = '{1}';", ConstEnv.inst_db_proxy_table_name, _proxy);

            if (dt == null || dt.Rows.Count == 0)
            {
                insert("INSERT INTO {0} (proxy) VALUES ('{1}');", ConstEnv.inst_db_proxy_table_name, _proxy);
                dt = select("SELECT * FROM {0} WHERE proxy = '{1}';", ConstEnv.inst_db_proxy_table_name, _proxy);
            }
            return int.Parse(dt.Rows[0]["id"].ToString());
        }

        public int GetGroupId(string group_name, int _user_id)
        {
            DataTable dt = select("SELECT * FROM `{0}` WHERE group_name = '{1}' AND user_id = '{2}';", ConstEnv.inst_db_group_table_name, group_name, _user_id);

            if (dt == null || dt.Rows.Count == 0)
                return -1;
            
            return int.Parse(dt.Rows[0]["id"].ToString());
        }

        public int GetUserId(string _username)
        {
            DataTable dt = select("SELECT id FROM `{0}` WHERE user = '{1}';", ConstEnv.inst_db_user_table_name, _username);
            return int.Parse(dt.Rows[0]["id"].ToString());
        }
        public bool InsertAccount(string file_line, string group_name, int _user_id)
        {
            string[] vals = file_line.Split(';');
            string user = vals[0];
            string userpass = vals[1];
            string proxy = vals[2];
            string mail_server = vals[3];
            string mail = vals[4];
            string mailpass = vals[5];

            int proxy_id = GetProxyId(proxy);
            int mail_server_id = GetMailServerId(mail_server);
            int group_id = GetGroupId(group_name, _user_id);

            DataTable ua_dt = select("SELECT * FROM {0} ORDER BY RAND() LIMIT 1;", ConstEnv.inst_db_user_agent_table_name);

            string ua_id = string.Empty;
            if (ua_dt == null || ua_dt.Rows.Count == 0)
                Program.log_info($"No Random User Agent.");
            else
                ua_id = ua_dt.Rows[0]["id"].ToString();

            DataTable dt = select("SELECT * FROM {0} WHERE emailaddr = '{1}';",
                ConstEnv.inst_db_account_table_name, mail);

            if (dt == null || dt.Rows.Count == 0)
            {
                insert("INSERT INTO {0} (username, userpass, emailaddr, emailpass, proxy_id, group_id, mail_server_id, user_agent_id, user_id) " +
                "VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');", ConstEnv.inst_db_account_table_name,
                user, userpass, mail, mailpass, proxy_id, group_id, mail_server_id, ua_id, _user_id);
                Program.log_info($"Account saved to group - {group_name} - from line - {file_line}");
                return true;
            }
            else
            {
                Program.log_info($"Account(emailaddr = {mail}) is existed." + "\n" + $"Line is skipped - {file_line}");
                return false;
            }
        }

        public bool InsertGroup(string group_name, int _user_id)
        {
            int group_id = GetGroupId(group_name, _user_id);

            if (group_id != -1)
            {
                Program.log_info($"Group - {group_name} is already existed.");
                return false;
            }

            insert("INSERT INTO `{0}` (group_name, user_id) VALUES ('{1}', '{2}');", ConstEnv.inst_db_group_table_name, group_name, _user_id);
            Program.log_info($"Group - {group_name} is added.");
            return true;
        }
        public bool IsExistedUserAgent(string _user_agent)
        {
            DataTable dt = select("SELECT * FROM `{0}` WHERE user_agent = '{1}';", ConstEnv.inst_db_user_agent_table_name, _user_agent);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public void InsertUserAgent(string _user_agent)
        {
            if (IsExistedUserAgent(_user_agent))
            {
                Program.log_error($"User-Agent is existed - {_user_agent}");
            }
            else
            {
                insert("INSERT INTO `{0}` (user_agent) VALUES ('{1}');", ConstEnv.inst_db_user_agent_table_name, _user_agent);
                Program.log_error($"User-Agent is added - {_user_agent}");
            }            
        }

        public void DeleteGroup(string group_name, int _user_id)
        {
            int group_id = GetGroupId(group_name, _user_id);

            delete("DELETE FROM `{0}` WHERE group_id = '{1}' AND user_id = '{2}';", ConstEnv.inst_db_account_table_name, group_id, _user_id);
            delete("DELETE FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_group_table_name, group_id);
        }

        public void DeleteAccountByID(int _acc_id)
        {
            delete("DELETE FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_account_table_name, _acc_id);
        }

        public void UpdateAccount(int _acc_id, string _username, string _userpass, string _emailaddr, string _emailpass, string _proxy)
        {
            int proxy_id = GetProxyId(_proxy);

            update("UPDATE `{0}` SET username = '{1}', userpass = '{2}', emailaddr = '{3}', emailpass = '{4}', proxy_id = '{5}' WHERE id = '{6}';", 
                ConstEnv.inst_db_account_table_name, _username, _userpass, _emailaddr, _emailpass, proxy_id, _acc_id);
        }

        public int VerifyUser(string _strUser, string _strPass)
        {
            DataTable dt = select("SELECT * FROM `{0}` WHERE user = '{1}';", ConstEnv.inst_db_user_table_name, _strUser);

            if (dt == null || dt.Rows.Count == 0)
            {
                Program.log_info($"No user {_strUser}");
                return ConstEnv.VERIFY_NoUser;
            }

            string pass = dt.Rows[0]["password"].ToString();

            if (pass == _strPass)
            {
                Program.log_info($"Verify success. user {_strUser}");
                return ConstEnv.VERIFY_SUCCESS;
            }
            else
            {
                Program.log_info($"Invalid password. user {_strUser}");
                return ConstEnv.VERIFY_InvalidPass;
            }
        }

        public bool InsertUser(string _strUser, string _strPass)
        {
            DataTable dt = select("SELECT * FROM `{0}` WHERE user = '{1}';", ConstEnv.inst_db_user_table_name, _strUser);

            if (dt == null || dt.Rows.Count == 0)
            {
                insert("INSERT INTO `{0}` (user, password) VALUES ('{1}', '{2}');", ConstEnv.inst_db_user_table_name, _strUser, _strPass);
                return true;
            }
            else
            {
                Program.log_info($"User {_strUser} is existed.");
                return false;
            }
        }

        public void UpdateUser(string _strUser, string _strPass, int _user_id)
        {
            update("UPDATE `{0}` SET user = '{1}', password = '{2}' WHERE id = '{3}';",
                ConstEnv.inst_db_user_table_name, _strUser, _strPass, _user_id);
        }

        public void GetUserById(int _user_id, out string _user, out string _pass)
        {
            _user = string.Empty;
            _pass = string.Empty;

            DataTable dt = select("SELECT * FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_user_table_name, _user_id);

            _user = dt.Rows[0]["user"].ToString();
            _pass = dt.Rows[0]["password"].ToString();
        }

        public DataTable GetAllUsers()
        {
            DataTable dt = select("SELECT * FROM `{0}`;", ConstEnv.inst_db_user_table_name);
            return dt;
        }

        public void GetUser(int _user_id, out string _user, out string _pass)
        {
            _user = string.Empty;
            _pass = string.Empty;

            DataTable dt = select("SELECT * FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_user_table_name, _user_id);

            _user = dt.Rows[0]["user"].ToString();
            _pass = dt.Rows[0]["password"].ToString();
        }

        public void DeleteUser(int _user_id)
        {
            delete("DELETE FROM `{0}` WHERE id = '{1}';", ConstEnv.inst_db_user_table_name, _user_id);
        }
    }
}
