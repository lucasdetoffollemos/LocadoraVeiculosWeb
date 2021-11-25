using AutoMapper;
using LocadoraVeiculos.Aplicacao.TaxaModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.TaxaModule;
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
    public class TaxaController : ControllerBase
    {
        private readonly ITaxaAppService taxaAppService;
        private readonly ITaxaRepository taxaRepository;
        private readonly IMapper mapper;
        private readonly INotificador notificador;

        public TaxaController(ITaxaAppService taxaAppService, ITaxaRepository taxaRepository, IMapper mapper, INotificador notificador)
        {
            this.taxaAppService = taxaAppService;
            this.taxaRepository = taxaRepository;
            this.mapper = mapper;
            this.notificador = notificador;
        }


        // GET: api/<TaxaController>
        [HttpGet]
        public List<TaxaListViewModel> GetAll()
        {
            var taxas = taxaRepository.SelecionarTodos();

            var viewModel = mapper.Map<List<TaxaListViewModel>>(taxas);

            return viewModel;

        }

        [HttpGet("{id}")]
        public ActionResult<TaxaDetailsViewModel> Get(int id)
        {

            var taxaSelecionada = taxaRepository.SelecionarPorId(id);

            if (taxaSelecionada == null)
                return NotFound(id);

            var viewModel = mapper.Map<TaxaDetailsViewModel>(taxaSelecionada);


            return Ok(viewModel);
        }

        // POST api/<TaxaController>
        [HttpPost]
        public ActionResult<TaxaCreateViewModel> Create(TaxaCreateViewModel viewModel)
        {
            if(ModelState.IsValid == false)
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    notificador.RegistrarNotificacao(erroMsg);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            Taxa taxa = mapper.Map<Taxa>(viewModel);

            bool registroRealizado = taxaAppService.RegistrarNovaTaxa(taxa);

            if (registroRealizado == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return CreatedAtAction(nameof(Create), viewModel);



        }

        // PUT api/<TaxaController>/5
        [HttpPut("{id}")]
        public ActionResult<TaxaEditViewModel> Edit(int id,  TaxaEditViewModel viewModel)
        {

            if (ModelState.IsValid == false)
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    notificador.RegistrarNotificacao(erroMsg);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            Taxa taxa = mapper.Map<Taxa>(viewModel);

            bool edicaoRealizada = taxaAppService.EditarTaxa(id, taxa);

            if (edicaoRealizada == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return Ok(viewModel);
        }

        // DELETE api/<TaxaController>/5
        [HttpDelete("{id}")]
        public ActionResult<ParceiroCreateViewModel> Delete(int id)
        {
            if (ModelState.IsValid == false)
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    notificador.RegistrarNotificacao(erroMsg);
                }

                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            var delecaoRealizada = taxaAppService.ExcluirTaxa(id);

            if (delecaoRealizada == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return Ok(id);

        }
    }
}
