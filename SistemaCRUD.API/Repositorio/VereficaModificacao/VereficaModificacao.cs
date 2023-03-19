using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.VereficaModificacao
{
    //Essa Classe e responsavel para identificar em qual coluna esta a modificação
    public class VereficaModificacao
    {
        public EmpresaModel empresaSemUpdate { get; set; }
        public ProdutoModel produtoSemUpdate { get; set; }
        public Type tipoColuna { get; set; }
        public object modificacao;
        public string VereficaEmpresa(EmpresaModel empresa)
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
        public string VereficaProduto(ProdutoModel produto)
        {
            if (produto.Nome != produtoSemUpdate.Nome)
            {
                modificacao = produto.Nome;
                tipoColuna = produto.Nome.GetType();
                return new string("Nome");
            }
            if (produto.Descricao != produtoSemUpdate.Descricao)
            {
                modificacao = produto.Descricao;
                tipoColuna = produto.Descricao.GetType();
                return new string("Descricao");
            }

            if (produto.Custo != produtoSemUpdate.Custo)
            {
                modificacao = produto.Custo;
                tipoColuna = produto.Custo.GetType();
                return new string("Custo");
            }
            if (produto.Preco != produtoSemUpdate.Preco)
            {
                modificacao = produto.Preco;
                tipoColuna = produto.Preco.GetType();
                return new string("Preco");
            }
            if (produto.Porcetagem != produtoSemUpdate.Porcetagem)
            {
                modificacao = produto.Porcetagem;
                tipoColuna = produto.Porcetagem.GetType();
                return new string("Porcetagem");
            }
            if (produto.Quantidade != produtoSemUpdate.Quantidade)
            {
                modificacao = produto.Quantidade;
                tipoColuna = produto.Quantidade.GetType();
                return new string("Quantidade");
            }

            if (produto.Empresa.IdEmpresa != produtoSemUpdate.Empresa.IdEmpresa)
            {
                modificacao = produto.Empresa.IdEmpresa;
                tipoColuna = produto.Empresa.IdEmpresa.GetType();
                return new string("id_Empresa");
            }

            if (produto.Tipo.IdTipo != produtoSemUpdate.Tipo.IdTipo)
            {
                modificacao = produto.Tipo.IdTipo;
                tipoColuna = produto.Tipo.IdTipo.GetType();
                return new string("id_Tipo");
            }
            return null;
        }
    }
}
