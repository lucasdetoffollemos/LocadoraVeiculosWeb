using AutoMapper;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class CupomProfile : Profile 
    {

        public CupomProfile()
        {
 
            CreateMap<Cupom, CupomListViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoCupomEnum)src.Tipo));

            CreateMap<Cupom, CupomDetailsViewModel>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (int)src.Tipo));

            CreateMap<CupomCreateViewModel, Cupom>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoCupomEnum)src.Tipo));

            CreateMap<CupomEditViewModel, Cupom>()
                    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoCupomEnum)src.Tipo));
        }

      

    }
}
