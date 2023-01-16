using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Cidade.Interface
{
    public interface IRepositorioCidade
    {
        public Task<bool> Insert(CidadeModel cidade);
        public Task<IEnumerable<CidadeModel>> SelectAll();
        public Task<CidadeModel> SelectId(int id);
        public Task Update(CidadeModel cidade);
        public Task Delete (int id);
    }
}
