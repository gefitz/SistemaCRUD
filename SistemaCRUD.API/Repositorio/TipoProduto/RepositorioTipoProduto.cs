using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Data.TipoProduto.Interface;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.TipoProduto.Interface;

namespace SistemaCRUD.API.Repositorio.TipoProduto
{
    public class RepositorioTipoProduto : IRepositorioTipoProduto
    {
        private readonly ITipoProduto _commands;

        public RepositorioTipoProduto(ITipoProduto commands)
        {
            _commands = commands;
        }

        public async Task Delete(int id)
        {
            await _commands.Delete(id);
        }

        public async Task<bool> Insert(TipoProdutoModel tipoProduto)
        {
            await _commands.Insert(tipoProduto);
            return true;
        }

        public async Task<IEnumerable<TipoProdutoModel>> SelectAll()
        {
            return await _commands.SelectAll();
           
            

        }

        public async Task<TipoProdutoModel> SelectId(int id)
        {
            return await _commands.Select(id);
        }

        public async Task Update(TipoProdutoModel tipoProduto)
        {
            var tipoProdutoSemUpdate = await _commands.Select(tipoProduto.IdTipo);
            if (tipoProdutoSemUpdate.TipoProduto != tipoProduto.TipoProduto)
            {
                await _commands.Update(tipoProduto.IdTipo, "Nome_Tipo", tipoProduto.TipoProduto);
            }  
        }
    }
}
