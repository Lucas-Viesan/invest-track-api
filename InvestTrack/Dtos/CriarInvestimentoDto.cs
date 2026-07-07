using System.ComponentModel.DataAnnotations;

namespace InvestTrack.Dtos
{
    public class CriarInvestimentoDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "O nome do ativo deve conter no minímo 3 caracteres")]
        [MaxLength(10, ErrorMessage = "O nome do ativo não pode exceder 10 caracteres")]
        public string NomeAtivo { get; set; }

        [Required]
        public string Tipo { get; set; }
        public decimal ValorAplicado { get; set; }

        public DateTime DataCompra { get; set; }

        public int CarteiraId { get; set; }

    }
}
