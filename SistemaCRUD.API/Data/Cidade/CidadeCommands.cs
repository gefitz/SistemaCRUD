using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Models;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Cidade
{
    public class CidadeCommands : ICidade
    {
        private readonly IConnection _connection;

        public CidadeCommands(IConnection connection)
        {
            _connection = connection;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(CidadeModel cidade)
        {
            #region queryInsert
            string queryInsert = $"use SistemCRUD; Insert into tbl_Cidades values (" +
                $"'{cidade.Nome}',{cidade.Estado.IdEstado})";
            #endregion

            using(var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryInsert, conn);

                try
                {
                    await cmd.ExecuteReaderAsync();
                }
                catch(Exception ex) { }
            }
        }

        public Task<IEnumerable<CidadeModel>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<CidadeModel> SelectId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, string coluna, string valor)
        {
            throw new NotImplementedException();
        }
    }
}
