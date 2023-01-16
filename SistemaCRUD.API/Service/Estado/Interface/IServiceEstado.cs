using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Estado.Interface
{
    public interface IServiceEstado
    {
        public Task<bool> Insert(EstadoDTO estado);
        public Task<IEnumerable<EstadoDTO>> GetAll();
        public Task<EstadoDTO> GetId(int id);
        public Task Update(EstadoDTO estado);
        public Task Delete(int id);
    }
}
