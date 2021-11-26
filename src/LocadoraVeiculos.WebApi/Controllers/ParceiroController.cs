using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.WebApi.Controllers.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : BaseController<Parceiro,
                                                     ParceiroListViewModel,
                                                     ParceiroDetailsViewModel,
                                                     ParceiroCreateViewModel,
                                                     ParceiroEditViewModel>
    {

        public ParceiroController(IMapper mapper, ParceiroAppService parceiroAppService, INotificador notificador) : base(parceiroAppService, mapper, notificador)
        {
        }
    }
}
