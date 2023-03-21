using Bot;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHelper
{
    public class DbBaseHelper
    {
        private DbConnection m_connection = null;
        private Object m_locker = new object();
        public DbConnection Connection
        {
            get { return m_connection; }
            set { m_connection = value; }
        }
        public DbBaseHelper()
        {
            m_connection = null;
        }
        public DbBaseHelper(DbConnection p_connection)
        {
            m_connection = p_connection;
        }
        public List<string> get_table_names()
        {
            List<String> table_names = new List<String>();

            lock (m_locker)
            {
                string query = string.Format("show tables from {0}", m_connection.get_database_name());
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m_connection.Connection;
                cmd.CommandText = query;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table_names.Add(reader.GetString(0));
                    }
                }
            }
            return table_names;
        }
        public DataTable select(string format, params object[] args)
        {
            DataTable dt = null;
            string query = string.Format(format, args);

            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            Program.log_info($"##### select : {query}");

            lock (m_locker)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(query, m_connection.Connection);
                dt = new DataTable();
                dataAdapter.Fill(dt);
            }

            Program.log_info(string.Format("##### select ret rows num = {0}", (dt != null && dt.Rows != null) ? dt.Rows.Count : 0));

            return dt;
        }
        public void insert(string format, params object[] args)
        {
            string query = string.Format(format, args);

            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            Program.log_info($"##### insert : {query}");

            lock (m_locker)
            {
                using (MySqlTransaction tr = m_connection.Connection.BeginTransaction())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = m_connection.Connection;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
            }

            Program.log_info("##### insert <<<");
        }
        public void update(string format, params object[] args)
        {
            MySqlTransaction tr = null;
            string query = string.Format(format, args);

            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            Program.log_info($"##### update : {query}");

            lock (m_locker)
            {
                tr = m_connection.Connection.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m_connection.Connection;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                tr.Commit();
            }

            Program.log_info("##### update <<<");
        }
        public void delete(string format, params object[] args)
        {
            MySqlTransaction tr = null;
            string query = string.Format(format, args);

            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            Program.log_info($"##### delete : {query}");

            lock (m_locker)
            {
                tr = m_connection.Connection.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m_connection.Connection;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                tr.Commit();
            }

            Program.log_info("##### delete <<<");
        }
        public void clear_table(string table_name)
        {
            string query = string.Format("TRUNCATE TABLE {0};", table_name);

            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            Program.log_info($"##### clear_table : {query}");

            lock (m_locker)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m_connection.Connection;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }

            Program.log_info("##### clear_table <<<");
        }
        public void fill_table(string table_name, DataTable dt)
        {
            clear_table(table_name);
            insert_table(table_name, dt);
        }
        public void update_table(string table_name, DataTable dt, string primary_key = "id")
        {
            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            lock (m_locker)
            {
                using (MySqlTransaction tr = m_connection.Connection.BeginTransaction())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string query = $"UPDATE {table_name} SET ";

                        int i = 0;
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == primary_key)
                                continue;

                            if (i++ == 0)
                                query += $"{col.ColumnName} = '{row[col.ColumnName].ToString()}'";
                            else
                                query += $", {col.ColumnName} = '{row[col.ColumnName].ToString()}'";
                        }

                        query += $" WHERE {primary_key} = '{row[primary_key]}';";

                        Program.log_info($"##### update_table : {query}");

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = m_connection.Connection;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
            }

            Program.log_info("##### update_table <<<");
        }
        public DataTable load_table(string table_name)
        {
            DataTable dt = null;

            string query = string.Format("SELECT * FROM {0};", table_name);

            if (m_connection.is_opened == true)
            {
                lock (m_locker)
                {
                    MySqlCommand cmd = new MySqlCommand(query, m_connection.Connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    dt = new DataTable();
                    dt.Load(dataReader);

                    dataReader.Close();
                }
            }
            return dt;
        }
        public void insert_table(string table_name, DataTable dt)
        {
            BulkInsertMySQL(table_name, dt);
        }
        public void insert_table1(string table_name, DataTable dt)
        {
            string query = string.Format("SELECT * FROM {0};", table_name);

            if (m_connection.is_opened == true)
            {
                lock (m_locker)
                {
                    MySqlCommand mySqlCmd = new MySqlCommand(query, m_connection.Connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCmd);
                    adapter.Fill(dt);
                    MySqlCommandBuilder myCB = new MySqlCommandBuilder(adapter);
                    adapter.UpdateCommand = myCB.GetUpdateCommand();

                    adapter.Update(dt);
                }
            }
        }
        public void BulkInsertMySQL(string table_name, DataTable dt)
        {
            if (!m_connection.is_opened)
                throw new Exception("Not connected");

            lock (m_locker)
            {
                using (MySqlTransaction tran = m_connection.Connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = m_connection.Connection;
                        cmd.Transaction = tran;
                        cmd.CommandText = $"SELECT * FROM " + table_name + " limit 0";

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.UpdateBatchSize = 10000;
                            using (MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter))
                            {
                                cb.SetAllValues = true;
                                adapter.Update(dt);
                                tran.Commit();
                            }
                        };
                    }
                }
            }
        }
    }
}
