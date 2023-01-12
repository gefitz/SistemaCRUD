using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Cidade.Interface
{
    public interface IRepositorioCidade
    {
        public Task<bool> Insert(CidadeModel cidade);
    }
}
