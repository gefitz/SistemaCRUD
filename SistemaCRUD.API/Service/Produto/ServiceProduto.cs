using AutoMapper;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Produto.Interfaces;
using SistemaCRUD.API.Service.Produto.Interface;

namespace SistemaCRUD.API.Service.Produto
{
    public class ServiceProduto : IServiceProduto
    {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ServiceProduto(IProdutoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task Insert(ProdutoDTO produto)
        {
            await _repositorio.Insert(_mapper.Map<ProdutoModel>(produto));
        }

        public async Task<IEnumerable<ProdutoDTO>> SelectAll()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _repositorio.SelectAll());
        }

        public async Task<ProdutoDTO> SelectId(int id)
        {
            return _mapper.Map<ProdutoDTO>(await _repositorio.SelectId(id));
        }

        public async Task<bool> Update(ProdutoDTO produto)
        {
            if (await _repositorio.Update(_mapper.Map<ProdutoModel>(produto)))
                return true;
            return false;
        }
    }
}
