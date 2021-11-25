using AutoMapper;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class TaxaProfile : Profile
    {
        public TaxaProfile()
        {
            CreateMap<Taxa, TaxaListViewModel>();

            CreateMap<Taxa, TaxaDetailsViewModel>();

            CreateMap<TaxaCreateViewModel, Taxa>();

            CreateMap<TaxaEditViewModel, Taxa>();

            //CreateMap<Locacao, LocacaoListViewModel>();
        }

       
    }
}
