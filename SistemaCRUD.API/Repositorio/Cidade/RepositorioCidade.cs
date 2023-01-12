using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Models;
using SistemaCRUD.API.Repositorio.Cidade.Interface;

namespace SistemaCRUD.API.Repositorio.Cidade
{
    public class RepositorioCidade : IRepositorioCidade
    {
        private readonly ICidade _commands;

        public RepositorioCidade(ICidade commands)
        {
            _commands = commands;
            
        }

        public async Task<bool> Insert(CidadeModel cidade)
        {
            await _commands.Insert(cidade);
            return true;
        }
    }
}
