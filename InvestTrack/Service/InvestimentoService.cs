using AutoMapper;
using InvestTrack.Context;
using InvestTrack.Dtos;
using InvestTrack.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InvestTrack.Service
{
    public class InvestimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public InvestimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DetalhesCriacaoInvestimentoDto> CriarInvestimento(CriarInvestimentoDto dto)
        {
            Investimento investimento = _mapper.Map<Investimento>(dto);

            var carteira = await _context.Carteiras
                .FirstOrDefaultAsync(c => c.Id == investimento.CarteiraId);

            if (carteira == null)
                throw new Exception("A carteira não foi encontrada.");

            bool existe = await _context.Investimentos
                .AnyAsync(i =>
                    i.CarteiraId == investimento.CarteiraId &&
                    i.NomeAtivo == investimento.NomeAtivo);

            if (existe)
                throw new Exception("Esse ativo já existe na carteira.");

            VerificaValorAplicado(dto);

            investimento.DataCompra = DateTime.UtcNow;
            _context.Investimentos.Add(investimento);
            await _context.SaveChangesAsync();
            var detalhesDto = _mapper.Map<DetalhesCriacaoInvestimentoDto>(investimento);

            return detalhesDto;
        }


        public void VerificaValorAplicado(CriarInvestimentoDto dto)
        {
            if (dto.ValorAplicado <= 0)
            {
                throw new Exception("Valor aplicado deve ser maior que 0.00");
            }
        }

        public void VerificaValorAtual(CriarInvestimentoDto dto)
        {
            dto.ValorAplicado = 0 + dto.ValorAplicado;

            if(dto.ValorAplicado < 0)
            {
                throw new Exception("Valor atual nunca pode ser negativo");  

        }

    }
}
