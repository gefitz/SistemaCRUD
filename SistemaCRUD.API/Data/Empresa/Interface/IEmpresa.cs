using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Data.Empresa.Interface
{
    public interface IEmpresa
    {
        public Task Insert(EmpresaModel empresa);
        public Task<IEnumerable<EmpresaModel>> SelectAll();
        public Task<EmpresaModel> SelectId(int id);
        public Task Update(int id, string coluna, object modificacao,Type tipoColuna);
        public Task Delete(int id);
    }
}
