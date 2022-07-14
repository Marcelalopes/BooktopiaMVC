using System.ComponentModel.DataAnnotations;

namespace MVCBooktopia.Models
{
    public class ClienteModel
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(14)]
        public string CPF { get; set; }
        [MaxLength(9)]
        public string CEP { get; set; }
        [MaxLength(50)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }

        public virtual List<AluguelModel> AlugueisList { get; set; }
    }
}
