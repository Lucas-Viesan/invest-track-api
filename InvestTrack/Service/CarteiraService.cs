using AutoMapper;
using InvestTrack.Context;
using InvestTrack.Dtos;
using InvestTrack.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace InvestTrack.Service
{
    public class CarteiraService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public CarteiraService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DetalhesCriacaoCarteiraDto CriarCarteira(CriarCarteiraDto criarCarteiraDto)
        {
            Carteira carteira = _mapper.Map<Carteira>(criarCarteiraDto);
            carteira.DataCriacao = DateTime.UtcNow;
            carteira.Nome = criarCarteiraDto.Nome;
            _context.Carteiras.Add(carteira);
            _context.SaveChanges();

            var detalhesDto = _mapper.Map<DetalhesCriacaoCarteiraDto>(carteira);
            return detalhesDto;

        }

        public async Task<RetornarCarteiraPorIDDto> BuscarCarteiraPorId(int carteiraId)
        {
            var carteira =  _context.Carteiras
                .Include(c => c.Investimentos)
                .FirstOrDefault(c => c.Id == carteiraId);
            if (carteira == null)
            {
                throw new Exception("Carteira não encontrada");
            }
            var valor = await CalcularValorTotalCarteira(carteiraId);
            var dto = _mapper.Map<RetornarCarteiraPorIDDto>(carteira);
            dto.ValorTotalCarteira = valor.ValorTotalCarteira;

            return dto;
        }

        public async Task<CalcularInvestimentoDto> CalcularValorTotalCarteira(int id)
        {
            CalcularInvestimentoDto calcularInvestimentoDto = new CalcularInvestimentoDto();
            
            decimal valorTotal = await _context.Investimentos
                .Where(i => i.CarteiraId == id)
                .SumAsync(i => i.ValorAtual);

            calcularInvestimentoDto.ValorTotalCarteira = valorTotal;

            return calcularInvestimentoDto;
        }

        public void Excluir(int id)
        {
            var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.Id == id);
            if (carteira == null)
            {
                throw new Exception("Carteira não encontrada");
            }
            var investimento = carteira.Investimentos.FirstOrDefault(investimento => investimento.Id == id);
            if (investimento == null)
            {
                _context.Carteiras.Remove(carteira);
                _context.SaveChanges();
            }
            throw new Exception("Só será possível excluir a carteira, caso não haja invvestimentos associados");

        }
    }
}
