using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Cidade.Interface
{
    public interface IServiceCidade
    {
        public Task<IEnumerable<CidadeDTO>> SelectAll(int id);
        public Task<CidadeDTO> SelectById(int id);
        public Task<IEnumerable<CidadeDTO>> SelectIdEstado(int id);

    }
}
