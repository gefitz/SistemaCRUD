using Newtonsoft.Json;
using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Estado.Interface;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
  

        public async Task<IEnumerable<CidadeModel>> SelectAll(int id)
        {
            

            List<CidadeModel> listCidades = new List<CidadeModel>(await _commands.SelectAll(id));
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

        public async Task<IEnumerable<CidadeModel>> SelectIdEstado(int id)
        {
            
            return await _commands.SelectIdEstado(id);
        }
    }
}
