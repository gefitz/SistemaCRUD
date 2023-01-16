using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Cidade.Interface
{
    public interface IServiceCidade
    {
        public Task<bool> Insert(CidadeDTO cidade);
        public Task<IEnumerable<CidadeDTO>> SelectAll();
        public Task<CidadeDTO> SelectById(int id);
        public Task Update(CidadeDTO cidade);
        public Task Delete(int id);
    }
}
