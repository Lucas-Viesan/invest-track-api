using System.ComponentModel.DataAnnotations;

namespace InvestTrack.Dtos
{
    public class DetalhesCriacaoInvestimentoDto
    {
        public int Id { get; set; }

        public string NomeAtivo { get; set; }

        public string Tipo { get; set; }
        public decimal ValorAplicado { get; set; }

        public decimal ValorAtual { get; set; }

        public DateTime DataCompra { get; set; }

    }
}
