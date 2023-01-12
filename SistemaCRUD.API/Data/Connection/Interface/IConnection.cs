using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Connection.Interface
{
    public interface IConnection
    {
        public SqlConnection Closed();
        public SqlConnection Open();
    }
}
