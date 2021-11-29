using AutoMapper;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class ParceiroProfile : Profile
    {
        public ParceiroProfile()
        {
            CreateMap<Parceiro, ParceiroListViewModel>();

            CreateMap<Parceiro, ParceiroDetailsViewModel>();

            CreateMap<ParceiroCreateViewModel, Parceiro>();

            CreateMap<ParceiroEditViewModel, Parceiro>();

            CreateMap<Cupom, CupomListViewModel>();
        }
    }
}
