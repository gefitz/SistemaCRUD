using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Estado.Interface;

namespace SistemaCRUD.API.Repositorio.Cidade
{
    public class RepositorioCidade : IRepositorioCidade
    {
        private readonly ICidade _commands;
        private readonly IRepositorioEstado _estado;

        public RepositorioCidade(ICidade commands, IRepositorioEstado estado)
        {
            _commands = commands;
            _estado = estado;          
        }

        public async Task Delete(int id)
        {
            await _commands.Delete(id);
        }

        public async Task<bool> Insert(CidadeModel cidade)
        {
            await _commands.Insert(cidade);
            return true;
        }

        public async Task<IEnumerable<CidadeModel>> SelectAll()
        {
            List<CidadeModel> listCidades = new List<CidadeModel> (await _commands.SelectAll());
            for (int i = 0; i < listCidades.Count; i++)
            {
                var estado = await _estado.GetId(listCidades[i].Estado.IdEstado);
                listCidades[i].Estado = estado;
            }
            return listCidades;
            
        }

        public async Task<CidadeModel> SelectId(int id)
        {
            CidadeModel cidade = await _commands.SelectId(id);
            cidade.Estado = await _estado.GetId(cidade.Estado.IdEstado);
            return cidade;
        }

        public async Task Update(CidadeModel cidade)
        {
            var cidadeSemUpdate =await  _commands.SelectId(cidade.IdCidade);
            if(cidadeSemUpdate.Nome != cidade.Nome)
            {
                await _commands.Update(cidade.IdCidade, "Nome", cidade.Nome);
            }
            if (cidadeSemUpdate.Estado.IdEstado != cidade.Estado.IdEstado)
            {
                await _commands.Update(cidade.IdCidade, "id_Estado", cidade.Estado.IdEstado.ToString());
            }
        }
    }
}
