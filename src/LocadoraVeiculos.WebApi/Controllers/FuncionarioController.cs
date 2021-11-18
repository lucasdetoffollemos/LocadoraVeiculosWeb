using AutoMapper;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
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
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IFuncionarioAppService funcionarioAppService;
        private readonly IMapper mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IFuncionarioAppService funcionarioAppService, IMapper mapper)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.funcionarioAppService = funcionarioAppService;
            this.mapper = mapper;
        }


        [HttpGet]
        public List<FuncionarioListViewModel> GetAll()
        {
            var funcionarios = funcionarioRepository.SelecionarTodos();

            return mapper.Map<List<FuncionarioListViewModel>>(funcionarios);
        }

       
        [HttpGet("{id}")]
        public ActionResult<FuncionarioDetailsViewModel> Get(int id)
        {
            var funcionarioSelecionado = funcionarioRepository.SelecionarPorId(id);

            if(funcionarioSelecionado == null)
            {
                return NotFound(id);
            }

            var funcionarioVm = mapper.Map<FuncionarioDetailsViewModel>(funcionarioSelecionado);

            return Ok(funcionarioVm);
        }

        
        [HttpPost]
        public ActionResult<FuncionarioCreateViewModel> Create(FuncionarioCreateViewModel funcionarioVm)
        {
            Funcionario funcionario = mapper.Map<Funcionario>(funcionarioVm);

            var resultado = funcionarioAppService.RegistrarNovoFuncionario(funcionario);

            if(resultado == "Funcionario registrado com sucesso")
            {
                return CreatedAtAction(nameof(Create), funcionarioVm);
            }

            return NoContent();
        }

        
        [HttpPut("{id}")]
        public ActionResult<FuncionarioEditViewModel> Edit(int id, FuncionarioEditViewModel funcionarioVm)
        {
            if (id != funcionarioVm.Id)
                return BadRequest();


            Funcionario funcionario = mapper.Map<Funcionario>(funcionarioVm);

            var resultado = funcionarioAppService.EditarFuncionario(id, funcionario);

            if(resultado == "Funcionario editado com sucesso")
            {
                return Ok(funcionarioVm);
            }

            return NoContent();

        }

        
        [HttpDelete("{id}")]
        public ActionResult<FuncionarioCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var resultado = funcionarioAppService.ExcluirFuncionario(id);


            if (resultado == "Funcionario excluído com sucesso")
            {
                return Ok(id);
            }

            return NoContent();
        }
    }
}
