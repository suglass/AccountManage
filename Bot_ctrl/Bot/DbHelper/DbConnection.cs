using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;
using Bot;

namespace DbHelper
{
    public class DbConnection : IDisposable
    {
        private readonly MySqlConnection _connection;
        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        private SshClient _ssh_client;

        private readonly string _database;
        private readonly string _server;
        private readonly int _port;
        private readonly string _uid;
        private readonly string _password;
        private readonly bool _ssh;
        private readonly string _ssh_server;
        private readonly int _ssh_port;
        private readonly string _ssh_uid;
        private readonly string _ssh_password;
        private readonly string _ssh_keyfile;

        private bool _is_opened;
        public bool is_opened
        {
            get { return _is_opened; }
        }

        public string get_database_name()
        {
            return _database;
        }

        public DbConnection(string database)
        {
            _database = database;
            _server = Program.g_setting.inst_db_host;
            _port = Program.g_setting.inst_db_port;
            _uid = Program.g_db_user;
            _password = Program.g_db_pass;

            _ssh = false;
            _ssh_server = "";
            _ssh_port = 22;
            _ssh_uid = "";
            _ssh_password = "";
            _ssh_keyfile = "";

            _is_opened = false;

            _connection = new MySqlConnection();
            _connection.ConnectionString = String.Format("server={0};port={1};database={2};uid={3};password={4}", _server, _port, _database, _uid, _password);
        }
        public DbConnection(string database, string server, int port, string uid, string password, bool ssh = false, string ssh_server = "", int ssh_port = 22, string ssh_uid = "", string ssh_password = "", string ssh_keyfile = "")
        {
            ForwardedPortLocal portFwld = null;

            _database = database;

            _server = server;
            _port = port;
            _uid = uid;
            _password = password;

            _ssh = ssh;
            _ssh_server = ssh_server;
            _ssh_port = ssh_port;
            _ssh_uid = ssh_uid;
            _ssh_password = ssh_password;
            _ssh_keyfile = ssh_keyfile;

            _is_opened = false;

            if (ssh)
            {
                List<AuthenticationMethod> methods = new List<AuthenticationMethod>();

                if (_ssh_password != "")
                    methods.Add(new PasswordAuthenticationMethod(_ssh_uid, _ssh_password));

                if (_ssh_keyfile != "")
                {
                    var keyFile = new PrivateKeyFile(_ssh_keyfile);
                    var keyFiles = new[] { keyFile };
                    methods.Add(new PrivateKeyAuthenticationMethod(_ssh_uid, keyFiles));
                }

                ConnectionInfo connectionInfo = new ConnectionInfo(_ssh_server, _ssh_port, _ssh_uid, methods.ToArray());
                connectionInfo.Timeout = TimeSpan.FromSeconds(1000);

               
                _ssh_client = new SshClient(connectionInfo);
                _ssh_client.Connect();
                if (!_ssh_client.IsConnected)
                    throw new Exception("SSH connection is inactive");
                //portFwld = new ForwardedPortLocal("127.0.0.1"/*your computer ip*/, _server /*server ip*/, 3306 /*server mysql port*/);
                portFwld = new ForwardedPortLocal(IPAddress.Loopback.ToString(), "localhost", 3306);
                _ssh_client.AddForwardedPort(portFwld);
                portFwld.Start();
                if (!portFwld.IsStarted)
                    throw new Exception("port forwarding failed");
            }

            _connection = new MySqlConnection();
            if (!ssh)
                _connection.ConnectionString = String.Format("server={0};port={1};database={2};uid={3};password={4}", _server, _port, _database, _uid, _password);
            else
                _connection.ConnectionString = String.Format("server={0};database={1};uid={2};password={3};port={4}", portFwld.BoundHost, _database, _uid, _password, portFwld.BoundPort);
        }
        public void Open()
        {
            try
            {
                _connection.Open();
                _is_opened = true;
            }
            catch (MySqlException ex)
            {
                throw new DatabaseConnectionException("Cannot connect to server.", ex);
            }
        }

        public void Close()
        {
            try
            {
                if (_is_opened)
                    _connection.Close();
                if (_ssh_client.IsConnected)
                    _ssh_client.Disconnect();

                _is_opened = false;
            }
            catch (MySqlException ex)
            {
                throw new DatabaseConnectionException("Cannot disconnect from server.", ex);
            }
        }

        public void Dispose()
        {
            Close();
        }
        public int ExecuteStoredProcedure(string name, Dictionary<string, object> parameters)
        {
            if (!_is_opened)
                throw new Exception("Not connected.");
            using (var _command = new MySqlCommand() { Connection = _connection })
            {
                _command.CommandText = name;
                _command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var item in parameters)
                {
                    _command.Parameters.AddWithValue(item.Key, item.Value);
                }
                var count = _command.ExecuteNonQuery();
                return count;
            }
        }

        public int ExecuteStoredProcedure(string name)
        {
            return ExecuteStoredProcedure(name, new Dictionary<string, object>());
        }
    }

    public class DatabaseConnectionException : Exception
    {
        internal DatabaseConnectionException(string message, MySqlException inner) : base(message, inner)
        {
        }

        public int ErrorCode => ((MySqlException)InnerException).ErrorCode;
    }
}
