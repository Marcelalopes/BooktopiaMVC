using MVCBooktopia.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVCBooktopia.Models
{
    public class LivroModel
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public CategoriaEnum Categoria { get; set; }
        [MaxLength(30)]
        public string Autor { get; set; }
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public virtual List<AluguelModel> Alugueis { get; set; }
    }
}
