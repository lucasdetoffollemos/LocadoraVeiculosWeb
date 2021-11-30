using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.GrupoVeiculoModule
{
    public interface IGrupoVeiculoAppService
    {
        List<GrupoVeiculo> SelecionarTodos(bool carregarPlanos = false);
    }

    public class GrupoVeiculoAppService : ICadastravel<GrupoVeiculo>
    {

        private const string IdGrupoAutomovel_Format = "[Id do GrupoAutomovel: {GrupoAutomovelId}]";

        private const string GrupoAutomovelRegistrado_ComSucesso =
            "GrupoAutomovel registrado com sucesso";

        private const string GrupoAutomovelNaoRegistrado =
            "GrupoAutomovel NÃO registrado. Tivemos problemas com a inserção no banco de dados ";


        private const string GrupoAutomovelNaoEditado =
         "GrupoAutomovel não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string GrupoAutomovelEditado_ComSucesso =
            "GrupoAutomovel editado com sucesso";

        private const string GrupoAutomovelNaoExcluido =
           "GrupoAutomovel não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string GrupoAutomovelExcluido_ComSucesso =
            "GrupoAutomovel excluído com sucesso";

        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;

        private readonly INotificador notificador;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository, INotificador notificador)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
            this.notificador = notificador;
        }

        public bool Editar(int id, GrupoVeiculo grupoVeiculo)
        {
            GrupoVeiculoValidator validator = new GrupoVeiculoValidator();

            var resultado = validator.Validate(grupoVeiculo);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }





            var grupoVeiculoEditado = grupoVeiculoRepository.Editar(id, grupoVeiculo);

            if (grupoVeiculoEditado == false)
            {
                Log.Logger.Aqui().Warning(GrupoAutomovelNaoEditado + IdGrupoAutomovel_Format, id);

                notificador.RegistrarNotificacao(GrupoAutomovelNaoEditado);

                return false;
            }

            return true;
        }

        public bool Excluir(int id)
        {
            var grupoVeiculoExcluido = grupoVeiculoRepository.Excluir(id);

            if (grupoVeiculoExcluido == false)
            {
                Log.Logger.Aqui().Warning(GrupoAutomovelNaoExcluido + IdGrupoAutomovel_Format, id);

                notificador.RegistrarNotificacao(GrupoAutomovelNaoExcluido);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            var gp = grupoVeiculoRepository.SelecionarPorId(id);

            if (gp == null)
                return false;


            return true;
        }

        public bool InserirNovo(GrupoVeiculo grupoVeiculo)
        {
            GrupoVeiculoValidator validator = new GrupoVeiculoValidator();

            var resultado = validator.Validate(grupoVeiculo);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }


            var grupoVeiculoInserido = grupoVeiculoRepository.Inserir(grupoVeiculo);

            if (grupoVeiculoInserido == false)
            {
                Log.Logger.Aqui().Warning(GrupoAutomovelNaoRegistrado + IdGrupoAutomovel_Format, grupoVeiculo.Id);

                notificador.RegistrarNotificacao(GrupoAutomovelNaoRegistrado);

                return false;
            }

            return true;
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return grupoVeiculoRepository.SelecionarPorId(id);
        }

        //public List<GrupoVeiculo> SelecionarTodos(bool carregarPlanos = false)
        //{
        //    return grupoVeiculoRepository.SelecionarTodos(carregarPlanos);
        //}

        public List<GrupoVeiculo> SelecionarTodos()
        {
            return grupoVeiculoRepository.SelecionarTodos();
        }
    }
}
