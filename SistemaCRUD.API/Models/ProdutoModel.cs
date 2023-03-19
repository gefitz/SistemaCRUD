namespace SistemaCRUD.API.Models
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public EmpresaModel Empresa { get; set; }
        public TipoProdutoModel Tipo { get; set; }
        public decimal Preco { get; set; }
        public decimal Custo { get; set; }
        public int Porcetagem { get; set; }
        public int Quantidade { get; set; }

    }
}
