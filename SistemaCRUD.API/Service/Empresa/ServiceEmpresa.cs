using AutoMapper;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Empresa.Interface;
using SistemaCRUD.API.Service.Empresa.Interface;

namespace SistemaCRUD.API.Service.Empresa
{
    public class ServiceEmpresa : IServiceEmpresa
    {
        private readonly IRepositorioEmpresa _repositorio;
        private readonly IMapper _mapper;

        public ServiceEmpresa(IRepositorioEmpresa repositorio,IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task Insert(EmpresaDTO empresa)
        {
            await _repositorio.Insert(_mapper.Map<EmpresaModel>(empresa));
        }

        public async Task<IEnumerable<EmpresaDTO>> SelectAll()
        {
            return _mapper.Map<IEnumerable<EmpresaDTO>>(await _repositorio.SelectAll());
        }

        public async Task<EmpresaDTO> SelectId(int id)
        {
            return _mapper.Map<EmpresaDTO>(await _repositorio.SelectId(id));
        }

        public async Task<bool> Update(EmpresaDTO empresa)
        {
            if (await _repositorio.Update(_mapper.Map<EmpresaModel>(empresa)))
                return true;
            return false;
        }
    }
}
