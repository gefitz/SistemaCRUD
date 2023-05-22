using SistemaCRUD.API.Models;

namespace SistemaCRUD.API.Repositorio.VereficaModificacao
{
    //Essa Classe e responsavel para identificar em qual coluna esta a modificação
    public class VereficaModificacao
    {
        public EmpresaModel empresaSemUpdate { get; set; }
        public ProdutoModel produtoSemUpdate { get; set; }
        public List<Type> tipoColuna;

        public List<object> modificacao;
        public List<string> coluna;

        public VereficaModificacao()
        {
            this.tipoColuna = new List<Type>();
            this.modificacao = new List<object>();
            this.coluna = new List<string>();
        }

        public void VereficaEmpresa(EmpresaModel empresa)
        {
            if (empresa.Razao != empresaSemUpdate.Razao)
            {
                modificacao.Add(empresa.Razao);
                tipoColuna.Add(empresa.Razao.GetType());
                coluna.Add("Razao");
            }
            if (empresa.Fantasia != empresaSemUpdate.Fantasia)
            {
                modificacao.Add(empresa.Fantasia);
                tipoColuna.Add(empresa.Fantasia.GetType());
                coluna.Add("Fantasia");
            }

            if (empresa.CNPJ != empresaSemUpdate.CNPJ)
            {
                modificacao.Add(empresa.CNPJ);
                tipoColuna.Add(empresa.CNPJ.GetType());
                coluna.Add("CNPJ");
            }
            if (empresa.Rua != empresaSemUpdate.Rua)
            {
                modificacao.Add(empresa.Rua);
                tipoColuna.Add(empresa.Rua.GetType());
                coluna.Add("Rua");
            }
            if (empresa.Bairro != empresaSemUpdate.Bairro)
            {
                modificacao.Add(empresa.Bairro);
                tipoColuna.Add(empresa.Bairro.GetType());
                coluna.Add("Bairro");
            }
            if (empresa.Numero != empresaSemUpdate.Numero)
            {
                modificacao.Add(empresa.Numero);
                tipoColuna.Add(empresa.Numero.GetType());
                coluna.Add("Numero");
            }

            if (empresa.DDD != empresaSemUpdate.DDD)
            {
                modificacao.Add(empresa.DDD);
                tipoColuna.Add(empresa.DDD.GetType());
                coluna.Add("DDD");
            }

            if (empresa.Telefone != empresaSemUpdate.Telefone)
            {
                modificacao.Add(empresa.Telefone);
                tipoColuna.Add(empresa.Telefone.GetType());
                coluna.Add("Telefone");
            }

            if (empresa.Complemento != empresaSemUpdate.Complemento)
            {
                modificacao.Add(empresa.Complemento);
                tipoColuna.Add(empresa.Complemento.GetType());
                coluna.Add("Complemento");
            }
            if (empresa.CEP != empresaSemUpdate.CEP)
            {
                modificacao.Add(empresa.CEP);
                tipoColuna.Add(empresa.CEP.GetType());
                coluna.Add("CEP");
            }

        }
        public void VereficaProduto(ProdutoModel produto)
        {
            if (produto.Nome != produtoSemUpdate.Nome)
            {
                modificacao.Add(produto.Nome);
                tipoColuna.Add(produto.Nome.GetType());
                coluna.Add("Nome");
            }
            if (produto.Descricao != produtoSemUpdate.Descricao)
            {
                modificacao.Add(produto.Descricao);
                tipoColuna.Add(produto.Descricao.GetType());
                coluna.Add("Descricao");
            }

            if (produto.Custo != produtoSemUpdate.Custo)
            {
                modificacao.Add(produto.Custo);
                tipoColuna.Add(produto.Custo.GetType());
                coluna.Add("Custo");
            }
            if (produto.Preco != produtoSemUpdate.Preco)
            {
                modificacao.Add(produto.Preco);
                tipoColuna.Add(produto.Preco.GetType());
                coluna.Add("Preco");
            }
            if (produto.Porcetagem != produtoSemUpdate.Porcetagem)
            {
                modificacao.Add(produto.Porcetagem);
                tipoColuna.Add(produto.Porcetagem.GetType());
                coluna.Add("Porcetagem");
            }
            if (produto.Quantidade != produtoSemUpdate.Quantidade)
            {
                modificacao.Add(produto.Quantidade);
                tipoColuna.Add(produto.Quantidade.GetType());
                coluna.Add("Quantidade");
            }

            if (produto.Empresa.IdEmpresa != produtoSemUpdate.Empresa.IdEmpresa)
            {
                modificacao.Add(produto.Empresa.IdEmpresa);
                tipoColuna.Add(produto.Empresa.IdEmpresa.GetType());
                coluna.Add("id_Empresa");
            }

            if (produto.Tipo.IdTipo != produtoSemUpdate.Tipo.IdTipo)
            {
                modificacao.Add(produto.Tipo.IdTipo);
                tipoColuna.Add(produto.Tipo.IdTipo.GetType());
                coluna.Add("id_Tipo");
            }   
        }
    }
}
