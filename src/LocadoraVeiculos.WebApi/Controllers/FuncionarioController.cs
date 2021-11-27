using AutoMapper;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.WebApi.Controllers.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : BaseController<Funcionario,
                                                     FuncionarioListViewModel,
                                                     FuncionarioDetailsViewModel,
                                                     FuncionarioCreateViewModel,
                                                     FuncionarioEditViewModel>
    {

      
        public FuncionarioController(FuncionarioAppService funcionarioAppService, IMapper mapper, INotificador notificador): base(funcionarioAppService, mapper, notificador)
        {
        
        }


    }
}
