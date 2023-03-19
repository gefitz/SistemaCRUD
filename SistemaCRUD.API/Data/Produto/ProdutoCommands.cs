using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Produto.Interfaces;
using SistemaCRUD.API.Models;
using System.Data.SqlClient;

namespace SistemaCRUD.API.Data.Produto
{
    public class ProdutoCommands : IProduto
    {
        private readonly IConnection _connection;

        public ProdutoCommands(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            #region queryDelete
            string queryDelete = $"use SistemCRUD; Delete tbl_Produtos where id_Produto = {id}";
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

        public async Task Insert(ProdutoModel produto)
        {
            #region queryInsert
            string queryInsert = $"use SistemCRUD; Insert into tbl_Produtos values(" +
                $"{produto.Nome}," +
                $"'{produto.Descricao}'," +
                $"'{produto.Imagem}'," +
                $"{produto.Preco}," +
                $"{produto.Custo}," +
                $"{produto.Porcetagem}," +
                $"{produto.Quantidade},"+
                $"{produto.Empresa.IdEmpresa}," +
                $"{produto.Tipo.IdTipo},";
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

        public async Task<IEnumerable<ProdutoModel>> SelectAll()
        {
            #region querySelectAll
            string querySelectAll = "use SistemCRUD; Select * From tbl_Produtos";
            #endregion

            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelectAll, conn);
                try
                {
                    var read = await cmd.ExecuteReaderAsync();
                    List<ProdutoModel> produtos = new List<ProdutoModel>();
                    while (await read.ReadAsync())
                    {
                        ProdutoModel produto = new ProdutoModel
                        {
                            IdProduto = Convert.ToInt32(read["id_Produto"]),   
                            Nome = read["Nome"].ToString(),
                            Descricao = read["Descricao"].ToString(),
                            Imagem = read["Imagem"].ToString(),
                            Preco = Convert.ToDecimal(read["Preco"]),
                            Custo = Convert.ToDecimal(read["Custo"]),
                            Quantidade = Convert.ToInt32(read["Quantidade"]),
                            Porcetagem = Convert.ToInt32(read["Porcetagem"]),
                            Empresa = new EmpresaModel { IdEmpresa = Convert.ToInt32(read["id_Empresa"]) },
                            Tipo = new TipoProdutoModel { IdTipo = Convert.ToInt32(read["id_Tipo"]) },
                        };
                        produtos.Add(produto);
                    }
                    return produtos;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<ProdutoModel> SelectId(int id)
        {
            #region querySelectId
            string querySelectId = $"use SistemCRUD;select * from tbl_Produtos where id_Produto = {id}";
            #endregion 
            using (var conn = _connection.Open())
            {
                var cmd = new SqlCommand(querySelectId, conn);
                try
                {
                    ProdutoModel produto = new ProdutoModel();
                    var read = await cmd.ExecuteReaderAsync();
                    while (await read.ReadAsync())
                    {
                       produto = new ProdutoModel
                        {
                            IdProduto = Convert.ToInt32(read["id_Produto"]),
                            Nome = read["Nome"].ToString(),
                            Descricao = read["Descricao"].ToString(),
                            Imagem = read["Imagem"].ToString(),
                            Preco = Convert.ToDecimal(read["Preco"]),
                            Custo = Convert.ToDecimal(read["Custo"]),
                            Quantidade = Convert.ToInt32(read["Quantidade"]),
                            Porcetagem = Convert.ToInt32(read["Porcetagem"]),
                            Empresa = new EmpresaModel { IdEmpresa = Convert.ToInt32(read["id_Empresa"]) },
                            Tipo = new TipoProdutoModel { IdTipo = Convert.ToInt32(read["id_Tipo"]) },
                        };
                    }
                    return produto;
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
            if (tipoColuna.Name is "String")
            {
                queryUpdate = $"use SistemCRUD; Update tbl_Produtos set {coluna} = '{modificacao.ToString()}' where id_Produto = {id}";
            }
            else if (tipoColuna.Name is "Int32")
            {
                queryUpdate = $"use SistemCRUD; Update tbl_Produtos set {coluna} = {Convert.ToInt32(modificacao)} where id_Produto = {id}";
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
