using AutoMapper;
using LocadoraVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.WebApi.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LocadoraVeiculos.WebApi.ViewModels.GrupoVeiculoViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoVeiculoController : BaseController<GrupoVeiculo,
                                                     GrupoVeiculoListViewModel,
                                                     GrupoVeiculoDetailsViewModel,
                                                     GrupoVeiculoCreateViewModel,
                                                     GrupoVeiculoEditViewModel>
    {
        
        public GrupoVeiculoController(GrupoVeiculoAppService appService, IMapper mapper, INotificador notificador) : base (appService, mapper, notificador)
        {
            
        }


    }
}
