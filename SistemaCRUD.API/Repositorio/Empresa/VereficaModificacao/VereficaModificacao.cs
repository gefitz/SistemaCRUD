using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.Empresa.VereficaModificacao
{
    //Essa Classe e responsavel para identificar em qual coluna esta a modificação
    public class VereficaModificacao
    {
        public EmpresaModel empresaSemUpdate { get; set; }
        public Type tipoColuna { get; set; }
        public object modificacao;
        public string Verefica(EmpresaModel empresa)
        {
            if (empresa.Razao != empresaSemUpdate.Razao)
            {
                modificacao = empresa.Razao;
                tipoColuna = empresa.Razao.GetType();
                return new string("Razao");
            }
            if (empresa.Fantasia != empresaSemUpdate.Fantasia)
            {
                modificacao = empresa.Fantasia;
                tipoColuna = empresa.Fantasia.GetType();
                return new string("Fantasia");
            }

            if (empresa.CNPJ != empresaSemUpdate.CNPJ)
            {
                modificacao = empresa.CNPJ;
                tipoColuna = empresa.CNPJ.GetType();
                return new string("CNPJ");
            }
            if (empresa.Rua != empresaSemUpdate.Rua)
            {
                modificacao = empresa.Rua;
                tipoColuna = empresa.Rua.GetType();
                return new string("Rua");
            }
            if (empresa.Bairro != empresaSemUpdate.Bairro)
            {
                modificacao = empresa.Bairro;
                tipoColuna = empresa.Bairro.GetType();
                return new string("Bairro");
            }
            if (empresa.Numero != empresaSemUpdate.Numero)
            {
                modificacao = empresa.Numero;
                tipoColuna = empresa.Numero.GetType();
                return new string("Numero");
            }

            if (empresa.DDD != empresaSemUpdate.DDD)
            {
                modificacao = empresa.DDD;
                tipoColuna = empresa.DDD.GetType();
                return new string("DDD");
            }

            if (empresa.Telefone != empresaSemUpdate.Telefone)
            {
                modificacao = empresa.Telefone;
                tipoColuna = empresa.GetType();
                return new string("Telefone");
            }
            return null;
        }
    }
}
