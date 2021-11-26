using AutoMapper;
using LocadoraVeiculos.Aplicacao.TaxaModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.WebApi.Controllers.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaController : BaseController<Taxa,
                                                     TaxaListViewModel,
                                                     TaxaDetailsViewModel,
                                                     TaxaCreateViewModel,
                                                     TaxaEditViewModel>
    {
      
        public TaxaController(TaxaAppService taxaAppService,  IMapper mapper, INotificador notificador): base(taxaAppService, mapper, notificador)
        {
          
        }


    }
}
