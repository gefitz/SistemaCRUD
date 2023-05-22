using System.ComponentModel.DataAnnotations;

namespace SistemaCRUD.MVC.Models
{
    public class EmpresaModel
    {
        public int IdEmpresa { get; set; }
        [Required]
        public int CNPJ { get; set; }
        [Required]
        public string Razao { get; set; }
        [Required]
        
        public string Fantasia { get; set; }
        [Required]
        public int DDD { get; set; }
        [Required]
        public int Telefone { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public CidadeModel? Cidade { get; set; }
        public EstadoModel? Estado { get; set; }
        [Required]
        public int IdCidade { get; set; }
        [Required]
        public int IdEstado { get; set; }
    }
}
