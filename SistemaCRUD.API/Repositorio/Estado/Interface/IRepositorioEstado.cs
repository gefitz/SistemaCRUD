using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Estado.Interface
{
    public interface IRepositorioEstado
    {
        public Task<bool> Insert(EstadoModel estado);
        public Task<IEnumerable<EstadoModel>> GetAll();
        public Task<EstadoModel> GetId(int id);
        public Task Update(EstadoModel estado);
        public Task Delete(int id);
    }
}
