using InvestTrack.Models;

namespace InvestTrack.Dtos
{
    public class RetornarCarteiraPorIDDto
    {
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public ICollection<InvestimentoResumoDto> Investimentos { get; set; }

        public decimal ValorTotalCarteira { get; set; }
    }
}
