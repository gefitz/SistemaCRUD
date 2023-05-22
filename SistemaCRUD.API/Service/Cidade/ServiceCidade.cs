using AutoMapper;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Service.Cidade.Interface;

namespace SistemaCRUD.API.Service.Cidade
{
    public class ServiceCidade : IServiceCidade
    {
        private readonly IRepositorioCidade _repositorio;
        private readonly IMapper _mapper;

        public ServiceCidade(IRepositorioCidade repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CidadeDTO>> SelectAll(int id)
        {
            return _mapper.Map<IEnumerable<CidadeDTO>>(await _repositorio.SelectAll(id));
        }

        public async Task<CidadeDTO> SelectById(int id)
        {
            return _mapper.Map<CidadeDTO>(await _repositorio.SelectId(id));
        }

        public async Task<IEnumerable<CidadeDTO>> SelectIdEstado(int id)
        {
            return _mapper.Map<IEnumerable<CidadeDTO>>(await _repositorio.SelectIdEstado(id));
        }
    }
}
