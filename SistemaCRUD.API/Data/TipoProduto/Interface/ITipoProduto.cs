using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Data.TipoProduto.Interface
{
    public interface ITipoProduto
    {
        public Task Insert(TipoProdutoModel tipoProduto);
        public Task Update(int id, string coluna, string modificacao);
        public Task Delete(int id);
        public Task<IEnumerable<TipoProdutoModel>> SelectAll();
        public Task<TipoProdutoModel> Select(int id);
    }
}
