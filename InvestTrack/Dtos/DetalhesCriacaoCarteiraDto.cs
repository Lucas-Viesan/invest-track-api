using System.ComponentModel.DataAnnotations;

namespace InvestTrack.Dtos
{
    public class DetalhesCriacaoCarteiraDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
