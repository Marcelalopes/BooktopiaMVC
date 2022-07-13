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
        [DataType(DataType.Currency)]
        public decimal? ValorTotal { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAluguel { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }
        [ForeignKey("ClienteModel")]
        public Guid ClienteId { get; set; }
        [ForeignKey("LivroModel")]
        public Guid LivroId { get; set; }
        public Boolean Devolvido { get; set; } = false;

        public virtual ClienteModel Cliente { get; set; }
        public virtual LivroModel Livro { get; set; }
    }
}
