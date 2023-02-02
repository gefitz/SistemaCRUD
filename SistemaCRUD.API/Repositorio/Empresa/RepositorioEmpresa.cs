using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Empresa.Interface;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Empresa.Interface;

namespace SistemaCRUD.API.Repositorio.Empresa
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly IEmpresa _commands;
        private readonly IRepositorioCidade _cidade;

        public RepositorioEmpresa(IEmpresa commands, IRepositorioCidade cidade)
        {
            _commands = commands;
            _cidade = cidade;
        }

        public async Task Delete(int id)
        {
            await _commands.Delete(id);
        }

        public async Task Insert(EmpresaModel empresa)
        {
            empresa.Cidade = await _cidade.SelectId(empresa.Cidade.IdCidade);
            await _commands.Insert(empresa);
        }

        public async Task<IEnumerable<EmpresaModel>> SelectAll()
        {
            List<EmpresaModel> empresas = new List<EmpresaModel>(await _commands.SelectAll());
            for (int i = 0; i < empresas.Count; i++)
            {
                empresas[i].Cidade = await _cidade.SelectId(empresas[i].Cidade.IdCidade);
                
            }
            return empresas;

        }

        public async Task<EmpresaModel> SelectId(int id)
        {
            var empresa = await _commands.SelectId(id);
            empresa.Cidade = await _cidade.SelectId(empresa.Cidade.IdCidade);
            return empresa;
        }

        public async Task<bool> Update(EmpresaModel empresa)
        {
            var empresaSemUpdate = await SelectId(empresa.IdEmpresa);
            VereficaModificacao.VereficaModificacao verefica = new VereficaModificacao.VereficaModificacao();
            verefica.empresaSemUpdate = empresaSemUpdate;
           var coluna = verefica.Verefica(empresa);
            await _commands.Update(empresa.IdEmpresa, coluna, verefica.modificacao, verefica.tipoColuna);

            return true;
            
        }
    }
}
