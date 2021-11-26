using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.CupomModule
{
    public interface ICupomAppService
    {
        List<Cupom> SelecionarCuponsAtivos(DateTime date);
        string RegistrarNovoCupom(Cupom cupom);
        List<Cupom> SelecionarTodos();
        Cupom SelecionarPorId(int id);
        string ExcluirCupom(int id);
        string EditarCupom(int id, Cupom cupomAlterado);
    }

    public class CupomAppService : ICadastravel<Cupom>
    {
        private readonly ICupomRepository cupomRepository;
        private INotificador notificador;

        public CupomAppService(ICupomRepository cupomRepository,INotificador notificador)
        {
            this.cupomRepository = cupomRepository;
            this.notificador = notificador;
        }

        private const string IdCupomFormat = "[Id do Cupom: {CupomId}]";

        private const string CupomRegistrado_ComSucesso =
            "Cupom registrado com sucesso";

        private const string CupomNaoRegistrado =
            "Cupom NÃO registrado. Tivemos problemas com a inserção no banco de dados ";

        private const string CupomNaoEditado =
           "Cupom não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string CupomEditado_ComSucesso =
            "Cupom editado com sucesso";

        private const string CupomNaoExcluido =
           "Cupom não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string CupomExcluido_ComSucesso =
            "Cupom excluído com sucesso";


      
      

        public Cupom SelecionarPorId(int id)
        {
            return cupomRepository.SelecionarPorId(id);
        }

        public List<Cupom> SelecionarTodos()
        {
            return cupomRepository.SelecionarTodos();
        }

        public List<Cupom> SelecionarCuponsAtivos(DateTime data)
        {
            return cupomRepository.SelecionarCuponsAtivos(data);
        }

        public bool InserirNovo(Cupom cupom)
        {
            CupomValidator validator = new CupomValidator();

            var resultado = validator.Validate(cupom);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var cupomInserido = cupomRepository.Inserir(cupom);

            if (cupomInserido == false)
            {
                Log.Logger.Aqui().Warning(CupomNaoRegistrado + IdCupomFormat, cupom.Id);

                notificador.RegistrarNotificacao(CupomNaoRegistrado);

                return false;
            }

            return true;
        }

        public bool Editar(int id, Cupom cupom)
        {
            CupomValidator validator = new CupomValidator();

            var resultado = validator.Validate(cupom);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var cupomEditado = cupomRepository.Editar(id, cupom);

            if (cupomEditado == false)
            {
                Log.Logger.Aqui().Warning(CupomNaoEditado + IdCupomFormat, id);

                notificador.RegistrarNotificacao(CupomNaoEditado);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            var cupom = cupomRepository.SelecionarPorId(id);

            if (cupom == null)
                return false;

            return true;

        }

        public bool Excluir(int id)
        {
            var cupomExcluido = cupomRepository.Excluir(id);

            if (cupomExcluido == false)
            {
                Log.Logger.Aqui().Warning(CupomNaoExcluido + IdCupomFormat, id);

                notificador.RegistrarNotificacao(CupomNaoExcluido);

                return false;
            }

            return true;
        }
    }
}
