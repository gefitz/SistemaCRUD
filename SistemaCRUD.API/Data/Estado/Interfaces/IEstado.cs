using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Data.Estado.Interfaces
{
    public interface IEstado
    {
        public Task Insert(EstadoModel estado);
        public Task Update(int id,string coluna,string modificacao);
        public Task Delete(int id);
        public Task<IEnumerable<EstadoModel>> SelectAll();
        public Task<EstadoModel> Select(int id);

    }
}
