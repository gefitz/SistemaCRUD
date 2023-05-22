namespace SistemaCRUD.API.Models
{
    public class EmpresaModel
    {
        public int IdEmpresa { get; set; }
        public int CNPJ { get; set; }
        public string Razao { get; set; }
        public string  Fantasia { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public CidadeModel Cidade { get; set; }
        public EstadoModel Estado { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
    }
}
