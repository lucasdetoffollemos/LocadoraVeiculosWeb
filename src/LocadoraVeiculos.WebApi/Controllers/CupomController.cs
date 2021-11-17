using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository cupomRepository;
        private readonly IParceiroRepository parceiroReporitoy;
        private readonly ICupomAppService cupomAppService;
        private readonly IMapper mapper;

        public CupomController(ICupomRepository cupomRepository, IParceiroRepository parceiroReporitoy, ICupomAppService cupomAppService, IMapper mapper)
        {
            this.cupomRepository = cupomRepository;
            this.parceiroReporitoy = parceiroReporitoy;
            this.cupomAppService = cupomAppService;
            this.mapper = mapper;
        }


        [HttpGet]
        public List<CupomListViewModel> GetAll()
        {
            var cupons = cupomRepository.SelecionarTodos();

            var viewModel = mapper.Map<List<CupomListViewModel>>(cupons);

            return viewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<CupomDetailsViewModel> Get(int id)
        {
            var cupom = cupomRepository.SelecionarPorId(id);

            if (cupom == null)
                return NotFound(id);

            var viewModel = mapper.Map<CupomDetailsViewModel>(cupom);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<CupomCreateViewModel> Create(CupomCreateViewModel viewModel)
        {
            Cupom cupom = mapper.Map<Cupom>(viewModel);

            var resultado = cupomAppService.RegistrarNovoCupom(cupom);

            if (resultado == "Cupom registrado com sucesso")
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<CupomEditViewModel> Edit(int id, CupomEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Cupom cupom = mapper.Map<Cupom>(viewModel);

            var resultado = cupomAppService.EditarCupom(id, cupom);

            if (resultado == "Cupom editado com sucesso")
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CupomCreateViewModel> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var resultado = cupomAppService.ExcluirCupom(id);

            if (resultado == "Cupom excluído com sucesso")
            {
                return Ok(id);
            }

            return NoContent();
        }


    }
}
