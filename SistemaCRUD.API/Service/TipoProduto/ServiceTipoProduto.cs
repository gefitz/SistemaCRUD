using AutoMapper;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.TipoProduto.Interface;
using SistemaCRUD.API.Service.TipoProduto.Interface;

namespace SistemaCRUD.API.Service.TipoProduto
{
    public class ServiceTipoProduto : IServiceTipoProduto
    {
        private readonly IRepositorioTipoProduto _repositorio;
        private readonly IMapper _mapper;

        public ServiceTipoProduto(IRepositorioTipoProduto repository,IMapper mapper)
        {
            _repositorio = repository;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<bool> Insert(TipoProdutoDTO tipoProduto)
        {
            var tipoProdutoModel = _mapper.Map<TipoProdutoModel>(tipoProduto);
            await _repositorio.Insert(tipoProdutoModel);
            return true;
        }

        public async Task<IEnumerable<TipoProdutoDTO>> SelectAll()
        {
            return _mapper.Map<IEnumerable<TipoProdutoDTO>>(await _repositorio.SelectAll());
        }

        public async Task<TipoProdutoDTO> SelectId(int id)
        {
            return _mapper.Map<TipoProdutoDTO>(await _repositorio.SelectId(id));
        }

        public async Task Update(TipoProdutoDTO cidade)
        {
            await _repositorio.Update(_mapper.Map<TipoProdutoModel>(cidade));
        }
    }
}
