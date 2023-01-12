using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Models;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Estado
{
    public class EstadoCommand : IEstado
    {
        private readonly IConnection _connection;

        public EstadoCommand(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            #region queryDelete
            string queryDelete = $"use SistemCRUD;Delete tbl_Estados where id_Estado = {id}";
            #endregion
            using(var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryDelete,conn);
                try
                {
                    await cmd.ExecuteReaderAsync();
                }catch(Exception ex) { }
            }
        }

        public async Task Insert(EstadoModel estado)
        {

            #region queryInsert
            string queryInsert = $"use SistemCRUD;insert into tbl_Estados(Nome,Sigla) values(" +
                $"'{estado.Nome}','{estado.Sigla}')";
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

        public async Task<EstadoModel> Select(int id)
        {
            #region QuerySelect
            string querySelect = $"use SistemCRUD; Select * From tbl_Estados where id_Estado = {id}";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelect, conn);
                try
                {
                    var reader = await cmd.ExecuteReaderAsync();
                    EstadoModel estado = new EstadoModel();
                    while (await reader.ReadAsync())
                    {
                        estado.IdEstado = Convert.ToInt32(reader["id_Estado"]);
                        estado.Nome = reader["Nome"].ToString();
                        estado.Sigla = reader["Sigla"].ToString();

                    }
                    return estado;

                }
                catch (Exception ex) { return null; }
            }
        }

        public async Task<IEnumerable<EstadoModel>> SelectAll()
        {
            #region QuerySelectAll
            string querySelect = "use SistemCRUD; Select * From tbl_Estados";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelect, conn);
                try
                {
                    List<EstadoModel> estados = new List<EstadoModel>();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        EstadoModel estado = new EstadoModel();
                        estado.IdEstado = Convert.ToInt32(reader["id_Estado"]);
                        estado.Nome = reader["Nome"].ToString();
                        estado.Sigla = reader["Sigla"].ToString();

                        estados.Add(estado);
                    }
                    return estados;

                }
                catch (Exception ex) { return null; }
            }
        }

        public async Task Update(int id, string coluna, string modificacao)
        {
            #region queryUpdate
            string queryUpdate = $"use SistemCRUD;Update tbl_Estados set {coluna} = '{modificacao}' where id_Estado = {id}";
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
