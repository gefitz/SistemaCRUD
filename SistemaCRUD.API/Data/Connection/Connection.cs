using SistemaCRUD.API.Data.Connection.Interface;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Connection
{
    public class Connection : IConnection
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public Connection(string connectionString, SqlConnection connection)
        {
            _connectionString = connectionString;
            _connection = connection;
        }

        public SqlConnection Closed()
        {
            if (_connection != null)
            {
                _connection.Close();
                return _connection;
            }
            return _connection;
        }

        public SqlConnection Open()
        {
            if (_connection != null)
            {
                _connection.ConnectionString= _connectionString;
                _connection.Open();
                return _connection;
            }
            return _connection;

        }
    }
}
