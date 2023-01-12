namespace SistemaCRUD.API.Models
{
    public class CidadeModel
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public EstadoModel Estado { get; set; }
    }
}
