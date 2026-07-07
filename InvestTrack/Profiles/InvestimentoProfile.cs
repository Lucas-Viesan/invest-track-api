using AutoMapper;
using InvestTrack.Dtos;
using InvestTrack.Models;

namespace InvestTrack.Profiles
{
    public class InvestimentoProfile : Profile
    {
        public InvestimentoProfile()
        {
            CreateMap<CriarInvestimentoDto, Investimento>();
            CreateMap<Investimento, DetalhesCriacaoInvestimentoDto>();
        }
    }
}
