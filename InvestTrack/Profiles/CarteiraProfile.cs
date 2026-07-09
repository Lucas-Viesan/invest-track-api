using AutoMapper;
using InvestTrack.Dtos;
using InvestTrack.Models;

namespace InvestTrack.Profiles
{
    public class CarteiraProfile : Profile
    {
        public CarteiraProfile() 
        {
            CreateMap<CriarCarteiraDto, Carteira>();
            CreateMap<Carteira, DetalhesCriacaoCarteiraDto>();
            CreateMap<Carteira, RetornarCarteiraPorIDDto>();
        }
    }
}
