using SistemaCRUD.MVC.Models;

namespace SistemaCRUD.MVC.Service.Estado.Interface
{
    public interface IServiceEstado
    {
        public Task<IEnumerable<EstadoModel>> GetAll();
        public Task<EstadoModel> GetId(int id);
    }
}
