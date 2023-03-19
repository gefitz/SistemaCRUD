using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Produto.Interface
{
    public interface IServiceProduto
    {
        public Task Insert(ProdutoDTO produto);
        public Task<IEnumerable<ProdutoDTO>> SelectAll();
        public Task<ProdutoDTO> SelectId(int id);
        public Task<bool> Update(ProdutoDTO produto);
        public Task Delete(int id);
    }
}
