using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBooktopia.Models
{
    public class AluguelModel
    {
        [Key]
        public Guid Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Multa { get; set; }
        [DisplayName("Valor Total")]
        [DataType(DataType.Currency)]
        public decimal? ValorTotal { get; set; }
        [DisplayName("Data do Aluguel")]
        [DataType(DataType.Date)]
        public DateTime DataAluguel { get; set; }
        [DisplayName("Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }
        [DisplayName("Id do Cliente")]
        [ForeignKey("ClienteModel")]
        public Guid ClienteId { get; set; }
        [DisplayName("Id do Livro")]
        [ForeignKey("LivroModel")]
        public Guid LivroId { get; set; }
        public Boolean Devolvido { get; set; } = false;

        public virtual ClienteModel Cliente { get; set; }
        public virtual LivroModel Livro { get; set; }
    }
}
