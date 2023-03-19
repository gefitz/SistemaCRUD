using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Produto.Interfaces;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Empresa.Interface;
using SistemaCRUD.API.Repositorio.Produto.Interfaces;
using System.Windows.Input;

namespace SistemaCRUD.API.Repositorio.Produto
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly IProduto _commands;
        private readonly IRepositorioEmpresa _empresa;

        public ProdutoRepositorio(IProduto commands, IRepositorioEmpresa empresa)
        {
            _commands = commands;
            _empresa = empresa;
        }

        public async Task Delete(int id)
        {
            await _commands.Delete(id);
        }

        public async Task Insert(ProdutoModel produto)
        {
            produto.Empresa = await _empresa.SelectId(produto.Empresa.IdEmpresa);
            await _commands.Insert(produto);
        }

        public async Task<IEnumerable<ProdutoModel>> SelectAll()
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>(await _commands.SelectAll());
            for (int i = 0; i < produtos.Count; i++)
            {
                produtos[i].Empresa = await _empresa.SelectId(produtos[i].Empresa.IdEmpresa);

            }
            return produtos;
        }

        public async Task<ProdutoModel> SelectId(int id)
        {
            var produto = await _commands.SelectId(id);
            produto.Empresa = await _empresa.SelectId(produto.Empresa.IdEmpresa);
            return produto;
        }

        public async Task<bool> Update(ProdutoModel produto)
        {
            var produtoSemUpdate = await SelectId(produto.IdProduto);
            VereficaModificacao.VereficaModificacao verefica = new VereficaModificacao.VereficaModificacao();
            verefica.produtoSemUpdate = produtoSemUpdate;
            var coluna = verefica.VereficaProduto(produto);
            await _commands.Update(produto.IdProduto, coluna, verefica.modificacao, verefica.tipoColuna);

            return true;

        }
    }
}
