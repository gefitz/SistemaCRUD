using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.TipoProduto.Interface
{
    public interface IRepositorioTipoProduto
    {
        public Task<bool> Insert(TipoProdutoModel estado);
        public Task<IEnumerable<TipoProdutoModel>> SelectAll();
        public Task<TipoProdutoModel> SelectId(int id);
        public Task Update(TipoProdutoModel estado);
        public Task Delete(int id);
    }
}
