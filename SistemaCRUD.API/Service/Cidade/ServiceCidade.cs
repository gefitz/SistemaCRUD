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

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<bool> Insert(CidadeDTO cidade)
        {
            var cidadeModel = _mapper.Map<CidadeModel>(cidade);
            await _repositorio.Insert(cidadeModel);
            return true;
        }

        public async Task<IEnumerable<CidadeDTO>> SelectAll()
        {
            return _mapper.Map<IEnumerable<CidadeDTO>>(await _repositorio.SelectAll());
        }

        public async Task<CidadeDTO> SelectById(int id)
        {
            return _mapper.Map<CidadeDTO>(await _repositorio.SelectId(id));
        }

        public async Task Update(CidadeDTO cidade)
        {
            await _repositorio.Update(_mapper.Map<CidadeModel>(cidade));
        }
    }
}
