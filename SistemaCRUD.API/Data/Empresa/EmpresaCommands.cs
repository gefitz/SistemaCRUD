using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Empresa.Interface;
using SistemaCRUD.API.Models;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Empresa
{
    public class EmpresaCommands : IEmpresa
    {
        private readonly IConnection _connection;

        public EmpresaCommands(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            #region queryDelete
            string queryDelete = $"use SistemCRUD; Delete tbl_Empresas where id_Empresa = {id}";
            #endregion
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryDelete, conn);
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

        public async Task Insert(EmpresaModel empresa)
        {
            #region queryInsert
            string queryInsert = $"use SistemCRUD; Insert into tbl_Empresas values(" +
                $"{empresa.CNPJ}," +
                $"'{empresa.Razao}'," +
                $"'{empresa.Fantasia}'," +
                $"{empresa.DDD}," +
                $"{empresa.Telefone}," +
                $"'{empresa.CEP}',"+
                $"'{empresa.Rua}'," +
                $"{empresa.Numero}," +
                $"'{empresa.Bairro}'," +
                $"'{empresa.Complemento}',"+
                $"{empresa.IdCidade}," +
                $"{empresa.IdEstado});";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(queryInsert, conn);
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

        public async Task<IEnumerable<EmpresaModel>> SelectAll()
        {
            #region querySelectAll
            string querySelectAll = "use SistemCRUD; Select * From tbl_Empresas";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelectAll, conn);
                try
                {
                    var read = await cmd.ExecuteReaderAsync();
                    List<EmpresaModel> empresas = new List<EmpresaModel>();
                    while (await read.ReadAsync())
                    {
                        EmpresaModel emprea = new EmpresaModel
                        {
                            IdEmpresa = Convert.ToInt32(read["id_Empresa"]),
                            CNPJ = Convert.ToInt32(read["CNPJ"]),
                            Razao = read["Razao"].ToString(),
                            Fantasia = read["Fantasia"].ToString(),
                            DDD = Convert.ToInt32(read["DDD"]),
                            Telefone = Convert.ToInt32(read["Telefone"]),
                            Rua = read["Rua"].ToString(),
                            Bairro = read["Bairro"].ToString(),
                            Numero = Convert.ToInt32(read["Numero"]),
                            CEP = read["Cep"].ToString(),
                            Cidade = new CidadeModel { IdCidade = Convert.ToInt32(read["id_Cidade"]) },
                            Complemento = read["Complemento"].ToString(),
                        };
                        empresas.Add(emprea);
                    }
                    return empresas;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<EmpresaModel> SelectId(int id)
        {
            #region querySelectId
            string querySelectId = $"use SistemCRUD;select * from tbl_Empresas where id_Empresa = {id}";
            #endregion 
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelectId, conn);
                try
                {
                    EmpresaModel empresa = new EmpresaModel();
                    var read = await cmd.ExecuteReaderAsync();
                    while (await read.ReadAsync())
                    {
                        empresa = new EmpresaModel
                        {
                            IdEmpresa = Convert.ToInt32(read["id_Empresa"]),
                            CNPJ = Convert.ToInt32(read["CNPJ"]),
                            Razao = read["Razao"].ToString(),
                            Fantasia = read["Fantasia"].ToString(),
                            DDD = Convert.ToInt32(read["DDD"]),
                            Telefone = Convert.ToInt32(read["Telefone"]),
                            Rua = read["Rua"].ToString(),
                            Bairro = read["Bairro"].ToString(),
                            Numero = Convert.ToInt32(read["Numero"]),
                            Cidade = new CidadeModel { IdCidade = Convert.ToInt32(read["id_Cidade"]) },
                            CEP = read["CEP"].ToString(),
                            Complemento = read["Complemento"].ToString(),

                        };
                    }
                    return empresa;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task Update(int id, string coluna, object modificacao, Type tipoColuna)
        {
            #region QueryUpdate
            string queryUpdate = "";
            if (tipoColuna.Name is String)
            {
                queryUpdate = $"use SistemCRUD; Update tbl_Empresas set {coluna} = '{modificacao.ToString()}' where id_Empresa = {id}";
            }
            else if (tipoColuna.Name is "Int32")
            {
                queryUpdate = $"use SistemCRUD; Update tbl_Empresas set {coluna} = {Convert.ToInt32(modificacao)} where id_Empresa = {id}";
            }
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
