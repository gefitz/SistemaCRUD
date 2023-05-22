using SistemaCRUD.MVC.Models;

namespace SistemaCRUD.MVC.Service.Empresa.Interface
{
    public interface IServiceEmpresa
    {
        public Task Insert(EmpresaModel empresa);
        public Task<IEnumerable<EmpresaModel>> SelectAll();
        public Task<EmpresaModel> SelectId(int id);
        public Task<bool>Update(EmpresaModel empresa);
        public Task<bool> Delete(int id);
    }
}
