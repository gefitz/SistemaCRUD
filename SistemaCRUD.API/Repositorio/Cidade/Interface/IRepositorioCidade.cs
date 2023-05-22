using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Cidade.Interface
{
    public interface IRepositorioCidade
    {
        public Task<IEnumerable<CidadeModel>> SelectAll(int id);
        public Task<CidadeModel> SelectId(int id);
        public Task<IEnumerable<CidadeModel>>SelectIdEstado(int id);
    }
}
