using System.ComponentModel.DataAnnotations;

namespace InvestTrack.Models
{
    public class Carteira
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da carteira é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public ICollection<Investimento> Investimentos { get; set; } 
    }
}