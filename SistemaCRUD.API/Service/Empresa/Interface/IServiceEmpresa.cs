using SistemaCRUD.API.DTOS;

namespace SistemaCRUD.API.Service.Empresa.Interface
{
    public interface IServiceEmpresa
    {
        public Task Insert(EmpresaDTO empresa);
        public Task<IEnumerable<EmpresaDTO>> SelectAll();
        public Task<EmpresaDTO> SelectId(int id);
        public Task<bool>Update(EmpresaDTO empresa);
        public Task Delete(int id);
    }
}
