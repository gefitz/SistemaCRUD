using AutoMapper;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Estado.Interface;
using SistemaCRUD.API.Service.Estado.Interface;

namespace SistemaCRUD.API.Service.Estado
{
    public class ServiceEstado : IServiceEstado
    {
        private readonly IRepositorioEstado _repositorio;
        private readonly IMapper _mapper;

        public ServiceEstado(IRepositorioEstado repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<IEnumerable<EstadoDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<EstadoDTO>>(await _repositorio.GetAll());
        }

        public async Task<EstadoDTO> GetId(int id)
        {
            return _mapper.Map<EstadoDTO>(await _repositorio.GetId(id));
        }

        public async Task<bool> Insert(EstadoDTO estado)
        {
            var estadoModel = _mapper.Map<EstadoModel>(estado);
            return await _repositorio.Insert(estadoModel);
        }

        public async Task Update(EstadoDTO estado)
        {
            var estadoModel = _mapper.Map<EstadoModel>(estado);
            await _repositorio.Update(estadoModel);
        }
    }
}
