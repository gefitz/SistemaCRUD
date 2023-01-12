using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Cidade.Interface
{
    public interface IServiceCidade
    {
        public Task<bool> Insert(CidadeDTO cidade);
    }
}
