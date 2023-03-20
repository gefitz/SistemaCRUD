using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.TipoProduto.Interface
{
    public interface IServiceTipoProduto
    {
        public Task<bool> Insert(TipoProdutoDTO tipoProduto);
        public Task<IEnumerable<TipoProdutoDTO>> SelectAll();
        public Task<TipoProdutoDTO> SelectId(int id);
        public Task Update(TipoProdutoDTO tipoProduto);
        public Task Delete(int id);
    }
}
