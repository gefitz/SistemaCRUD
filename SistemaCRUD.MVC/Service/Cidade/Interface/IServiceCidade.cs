using SistemaCRUD.MVC.Models;

namespace SistemaCRUD.MVC.Service.Cidade.Interface
{
    public interface IServiceCidade
    {
        public Task<IEnumerable<CidadeModel>> GetCidadeList(int id);
    }
}
