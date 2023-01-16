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

        public async Task Delete(int id)
        {
            #region queryDelet
            string queryDelet = $"use SistemCRUD; Delete tbl_Cidades where id_Cidade = {id}";
            #endregion
            using (var conn = _connection.Open())
            {
                
                var cmd = new SqlCommand(queryDelet,conn);
                try
                {
                    await cmd.ExecuteReaderAsync();
                }
                catch (Exception)
                {

                    throw;
                }

            }
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

        public async Task<IEnumerable<CidadeModel>> SelectAll()
        {
            #region querySelectAll
            string querySelect = "use SistemCRUD; Select * From tbl_Cidades";
            #endregion
            using(var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelect, conn);
                try
                {
                    var cidadesResult = await cmd.ExecuteReaderAsync();
                    List<CidadeModel> listCidades = new List<CidadeModel>();
                    while(await cidadesResult.ReadAsync())
                    {
                        CidadeModel cidade = new CidadeModel
                        {
                            IdCidade = Convert.ToInt32(cidadesResult["id_Cidade"]),
                            Nome = cidadesResult["Nome"].ToString(),
                            Estado = new EstadoModel { IdEstado = Convert.ToInt32(cidadesResult["id_Estado"]) }
                        };
                        listCidades.Add(cidade);
                    }
                    return listCidades;
                }catch(Exception ex) { return null; }
            }
        }

        public async Task<CidadeModel> SelectId(int id)
        {
            #region querySelectId
            string querySelectId = $"use SistemCRUD;select * from tbl_Cidades where id_Cidade = {id}";
            #endregion
            using(var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelectId, conn);
                try
                {
                    var cidadesResult = await cmd.ExecuteReaderAsync();
                    CidadeModel cidade = new CidadeModel();
                    while(await cidadesResult.ReadAsync())
                    {
                        cidade.IdCidade = Convert.ToInt32(cidadesResult["id_Cidade"]);
                        cidade.Nome = cidadesResult["Nome"].ToString();
                        cidade.Estado = new EstadoModel { IdEstado = Convert.ToInt32(cidadesResult["id_Estado"]) };
                    }
                    return cidade;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task Update(int id, string coluna, string valor)
        {
            #region queryUpdate
            string queryUpdate = "";
            if(coluna == "Nome")
                queryUpdate = $"use SistemCRUD;Update tbl_Cidades set {coluna} ='{valor}' where id_Cidade = {id}";
            if(coluna == "id_Estado")
                queryUpdate = $"use SistemCRUD;Update tbl_Cidades set {coluna} = {valor} where id_Cidade = {id}";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryUpdate, conn);
                try
                {
                    await cmd.ExecuteReaderAsync();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
