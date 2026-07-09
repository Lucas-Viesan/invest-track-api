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
            investimento.ValorAtual = investimento.ValorAplicado;
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

        public InvestimentoResumoDto RecuperarInvestimentoPorId(int invest)
        {
            var investimento = _context.Investimentos.FirstOrDefault(i => i.Id == invest);
            if (investimento == null)
            {
                throw new Exception("Investimento não encontrado");
            }
            InvestimentoResumoDto dto = _mapper.Map<InvestimentoResumoDto>(investimento);

            return dto;
        }

        public InvestimentoResumoDto AtualizarInvestimento(int invest, AtualizaInvestimentoDto atualizacao)
        {
            var investimento = _context.Investimentos.FirstOrDefault(i => i.Id == invest);
            if (investimento == null)
            {
                throw new Exception("Investimento não encontrado");
            }
            VerificaValorAtual(atualizacao);
            investimento.ValorAtual = atualizacao.ValorAtual;
            _context.SaveChanges();

            InvestimentoResumoDto dto = _mapper.Map<InvestimentoResumoDto>(investimento);
            
            return dto;
        }

        public void VerificaValorAtual(AtualizaInvestimentoDto atualizacao)
        {
            if(atualizacao.ValorAtual < 0)
            {
                throw new Exception("Valor atual não pode ser negativo");
            }
        }

        public void DeletarInvestimento(int invest)
        {
            var investimento = _context.Investimentos.FirstOrDefault(i => i.Id == invest);
            if(investimento == null)
            {
                throw new Exception("Investimento não encontrado");
            }
            _context.Investimentos.Remove(investimento);
            _context.SaveChanges();
        }
    }
}
