using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Produto.Interfaces
{
    public interface IProdutoRepositorio
    {
        public Task Insert(ProdutoModel produto);
        public Task<IEnumerable<ProdutoModel>> SelectAll();
        public Task<ProdutoModel> SelectId(int id);
        public Task<bool> Update(ProdutoModel produto);
        public Task Delete(int id);
    }
}
