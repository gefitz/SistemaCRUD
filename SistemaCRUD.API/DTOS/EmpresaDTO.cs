using System.ComponentModel.DataAnnotations;

namespace SistemaCRUD.API.DTOS
{
    public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }
        public int CNPJ { get; set; }
        public string Razao { get; set; }
        public string  Fantasia { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public EstadoDTO? Estado { get; set; }
        public CidadeDTO? Cidade { get; set; }
        [Required]
        public int IdCidade { get; set; }
        [Required]
        public int IdEstado { get; set; }
    }
}
