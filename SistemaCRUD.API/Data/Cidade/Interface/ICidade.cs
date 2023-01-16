using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Data.Cidade.Interface
{
    public interface ICidade
    {
        public Task Insert(CidadeModel cidade);
        public Task Update(int id, string coluna,string valor);
        public Task Delete(int id);
        public Task<IEnumerable<CidadeModel>> SelectAll();
        public Task<CidadeModel> SelectId(int id);
    }
}
