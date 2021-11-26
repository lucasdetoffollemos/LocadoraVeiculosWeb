using AutoMapper;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocadoraVeiculos.WebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TListVM, TDetailVM, TCreateVM, TEditVM> : ControllerBase where TEntity : EntidadeBase<int>
    {

        private readonly ICadastravel<TEntity> appService;
        private readonly IMapper mapper;
        private readonly INotificador notificador;

        public BaseController(ICadastravel<TEntity> appService, IMapper mapper, INotificador notificador)
        {
            this.appService = appService;
            this.mapper = mapper;
            this.notificador = notificador;

        }


        // GET: api/<BaseController>
        [HttpGet]
        public ActionResult<List<TListVM>> GetAll()
        {
            var registros = appService.SelecionarTodos();

            var viewModel = mapper.Map<List<TListVM>>(registros);

            return viewModel;
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public ActionResult<TDetailVM> Get(int id)
        {
            var registro = appService.SelecionarPorId(id);

            if (registro == null)
                return NotFound(id);

            var viewModel = mapper.Map<TDetailVM>(registro);

            return Ok(viewModel);
        }

        // POST api/<BaseController>
        [HttpPost]
        public ActionResult<TCreateVM> Create(TCreateVM viewModel)
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

            var registro = mapper.Map<TEntity>(viewModel);

            bool registroRealizado = appService.InserirNovo(registro);

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

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public ActionResult<TEditVM> Edit(int id, TEditVM viewModel)
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

            var registro = mapper.Map<TEntity>(viewModel);

            bool edicaoRealizada = appService.Editar(id, registro);

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

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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

            var delecaoRealizada = appService.Excluir(id);

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
