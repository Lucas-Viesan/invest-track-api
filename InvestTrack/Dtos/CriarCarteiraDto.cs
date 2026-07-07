using System.ComponentModel.DataAnnotations;

namespace InvestTrack.Dtos
{
    public class CriarCarteiraDto
    {
        [Required(ErrorMessage = "O nome da carteira é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
