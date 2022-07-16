using MVCBooktopia.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBooktopia.Models
{
    public class LivroModel
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(30)]
        [DisplayName("Título do Livro")]
        public string Titulo { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de Lançamento")]
        public DateTime DataLancamento { get; set; }
        public CategoriaEnum Categoria { get; set; }
        [MaxLength(30)]
        public string Autor { get; set; }
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        public Boolean Ativo { get; set; } = true;
        public virtual List<AluguelModel> Alugueis { get; set; }
    }
}
