using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.TipoProduto.Interface;
using SistemaCRUD.API.Models;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.TipoProduto
{
    public class TipoProdutoCommands : ITipoProduto
    {
        private readonly IConnection _connection;

        public TipoProdutoCommands(IConnection connection)
        {
            _connection = connection;
        }
        public async Task Delete(int id)
        {
            #region queryDelete
            string queryDelete = $"use SistemCRUD;Delete tbl_TipoProdutos where id_Tipo = {id};";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryDelete, conn);
                try
                {
                    await cmd.ExecuteReaderAsync();
                }
                catch (Exception ex) { }
            }
        }

        public async Task Insert(TipoProdutoModel tipoPruduto)
        {

            #region queryInsert
            string queryInsert = $"use SistemCRUD;insert into tbl_TipoProdutos values(" +
                $"'{tipoPruduto.TipoProduto}')";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryInsert, conn);

                try
                {
                    await cmd.ExecuteReaderAsync();

                }
                catch (Exception ex) { var err = ex; }
            }
        }

        public async Task<TipoProdutoModel> Select(int id)
        {
            #region QuerySelect
            string querySelect = $"use SistemCRUD; Select * From tbl_TipoProdutos where id_Tipo = {id}";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelect, conn);
                try
                {
                    var reader = await cmd.ExecuteReaderAsync();
                    TipoProdutoModel tipoProduto = new TipoProdutoModel();
                    while (await reader.ReadAsync())
                    {
                        tipoProduto.IdTipo = Convert.ToInt32(reader["id_Tipo"]);
                        tipoProduto.TipoProduto= reader["Nome_Tipo"].ToString();
                       

                    }
                    return tipoProduto;

                }
                catch (Exception ex) { return null; }
            }
        }

        public async Task<IEnumerable<TipoProdutoModel>> SelectAll()
        {
            #region QuerySelectAll
            string querySelect = "use SistemCRUD; Select * From tbl_TipoProdutos";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelect, conn);
                try
                {
                    List<TipoProdutoModel> tipoProdutos = new List<TipoProdutoModel>();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        TipoProdutoModel tipoProduto = new TipoProdutoModel();
                        tipoProduto.IdTipo = Convert.ToInt32(reader["id_Tipo"]);
                        tipoProduto.TipoProduto = reader["Nome_Tipo"].ToString();

                        tipoProdutos.Add(tipoProduto);
                    }
                    return tipoProdutos;

                }
                catch (Exception ex) { return null; }
            }
        }

        public async Task Update(int id, string coluna, string modificacao)
        {
            #region queryUpdate
            string queryUpdate = $"use SistemCRUD;Update tbl_TipoProdutos set {coluna} = '{modificacao}' where id_Tipo = {id}";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryUpdate, conn);
                try
                {
                    await cmd.ExecuteReaderAsync();
                }
                catch (Exception ex) { }
            }
        }
    }
}
