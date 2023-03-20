using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Data.Produto.Interfaces
{
    public interface IProduto
    {
        public Task Insert(ProdutoModel produto);
        public Task<IEnumerable<ProdutoModel>> SelectAll();
        public Task<ProdutoModel> SelectId(int id);
        public Task Update(int id, string coluna, object modificacao, Type tipoColuna);
        public Task Delete(int id);
    }
}
