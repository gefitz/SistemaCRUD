namespace SistemaCRUD.API.DTOS
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public TipoProdutoDTO Tipo { get; set; }
        public float Preco { get; set; }
        public float Custo { get; set; }
        public int Porcetagem { get; set; }
    }
}
