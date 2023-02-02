using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Empresa.Interface
{
    public interface IRepositorioEmpresa
    {
        public Task Insert(EmpresaModel empresa);
        public Task<IEnumerable<EmpresaModel>> SelectAll();
        public Task<EmpresaModel>SelectId(int id);
        public Task<bool> Update(EmpresaModel empresa);
        public Task Delete(int id);
    }
}
