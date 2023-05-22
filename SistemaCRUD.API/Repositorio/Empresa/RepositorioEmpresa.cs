using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Empresa.Interface;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Empresa.Interface;
using SistemaCRUD.API.Repositorio.Estado.Interface;

namespace SistemaCRUD.API.Repositorio.Empresa
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly IEmpresa _commands;
        private readonly IRepositorioCidade _cidade;
        private readonly IRepositorioEstado _estado;

        public RepositorioEmpresa(IEmpresa commands, IRepositorioCidade cidade, IRepositorioEstado estado)
        {
            _commands = commands;
            _cidade = cidade;
            _estado = estado;
        }

        public async Task Delete(int id)
        {
            await _commands.Delete(id);
        }

        public async Task Insert(EmpresaModel empresa)
        {
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
            verefica.VereficaEmpresa(empresa);
            if (verefica.coluna.Count > 1)
            {
                for (int i = 0; i < verefica.coluna.Count; i++)
                {

                    await _commands.Update(empresa.IdEmpresa, verefica.coluna[i], verefica.modificacao[i], verefica.tipoColuna[i]);
                }
            }
            if(verefica.coluna.Count == 1)
                await _commands.Update(empresa.IdEmpresa, verefica.coluna[0], verefica.modificacao[0], verefica.tipoColuna[0]);
            return true;

        }
    }
}
