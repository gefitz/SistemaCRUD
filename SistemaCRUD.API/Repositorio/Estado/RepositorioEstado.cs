using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Estado.Interface;

namespace SistemaCRUD.API.Repositorio.Estado
{
    public class RepositorioEstado : IRepositorioEstado
    {
        private readonly IEstado _estadoData;


        public RepositorioEstado(IEstado estado)
        {
            _estadoData = estado;
        }

        public async Task Delete(int id)
        {
            await _estadoData.Delete(id);
        }

        public async Task<IEnumerable<EstadoModel>> GetAll()
        {
            return await _estadoData.SelectAll();
        }

        public async Task<EstadoModel> GetId(int id)
        {
            return await _estadoData.Select(id);
        }

        public async Task<bool> Insert(EstadoModel estado)
        {
            var listEstados = await GetAll();
            bool validacao = true;
            foreach (var item in listEstados)
            {
                if (item.Nome.Equals(estado.Nome) || item.Sigla.Equals(estado.Sigla))
                {
                    return false;
                }
            }

            await _estadoData.Insert(estado);

            return validacao;
        }

        public async Task Update(EstadoModel estado)
        {
            var estadoSemUpdate = await GetId(estado.IdEstado);
            if (!estadoSemUpdate.Nome.Equals(estado.Nome))
            {
                await _estadoData.Update(estado.IdEstado, "Nome", estado.Nome);
            }
            else if (!estadoSemUpdate.Sigla.Equals(estado.Sigla))
            {
                await _estadoData.Update(estado.IdEstado, "Sigla", estado.Sigla);
            }
        }
    }
}
