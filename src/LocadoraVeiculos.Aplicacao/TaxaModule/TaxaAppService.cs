using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.TaxaModule
{
    public interface ITaxaAppService
    {

        bool RegistrarNovaTaxa(Taxa taxa);
        Taxa SelecionarPorId(int id);
        bool ExcluirTaxa(int id);

        bool EditarTaxa(int id, Taxa taxa);
        List<Taxa> SelecionarTodos();

        List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas);
    }
    public class TaxaAppService : ITaxaAppService
    {

        private const string IdTaxaFormat = "[Id da Taxa: {TaxaId}]";

        private const string TaxaRegistrada_ComSucesso =
            "Taxa registrada com sucesso";

        private const string TaxaNaoRegistrada =
            "Taxa NÃO registrada. Tivemos problemas com a inserção no banco de dados ";


        private const string TaxaNaoEditada =
         "Taxa não editada. Tivemos problemas com a exclusão no banco de dados";

        private const string TaxaEditada_ComSucesso =
            "Taxa editada com sucesso";

        private const string TaxaNaoExcluida =
           "Taxa não excluída. Tivemos problemas com a exclusão no banco de dados";

        private const string TaxaExcluida_ComSucesso =
            "Taxa excluída com sucesso";


        private readonly ITaxaRepository taxaRepository;
        private INotificador notificador;

        public TaxaAppService(ITaxaRepository taxaRepository, INotificador notificador)
        {
            this.taxaRepository = taxaRepository;
            this.notificador = notificador;
        }

        public bool EditarTaxa(int id, Taxa taxa)
        {
            TaxaValidator validator = new();

            var resultado = validator.Validate(taxa);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var taxaEditada = taxaRepository.Editar(id, taxa);

            if (taxaEditada == false)
            {
                Log.Logger.Aqui().Warning(TaxaNaoEditada + IdTaxaFormat, id);

                notificador.RegistrarNotificacao(TaxaNaoEditada);

                return false;
            }

            return true;
        }

        public bool ExcluirTaxa(int id)
        {
            var taxaExcluida = taxaRepository.Excluir(id);

            if (taxaExcluida == false)
            {
                Log.Logger.Aqui().Warning(TaxaNaoExcluida + IdTaxaFormat, id);

                notificador.RegistrarNotificacao(TaxaNaoExcluida);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaTaxa(Taxa taxa)
        {
            TaxaValidator validator = new TaxaValidator();

            var resultado = validator.Validate(taxa);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

            var taxaInserida = taxaRepository.Inserir(taxa);

            if (taxaInserida == false)
            {
                Log.Logger.Aqui().Warning(TaxaNaoRegistrada + IdTaxaFormat, taxa.Id);

                notificador.RegistrarNotificacao(TaxaNaoRegistrada);

                return false;
            }

            return true;

        }

        public Taxa SelecionarPorId(int id)
        {
            return taxaRepository.SelecionarPorId(id);
        }

        public List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas)
        {
            return taxaRepository.SelecionarTaxasNaoAdicionadas(taxasJaAdicionadas);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxaRepository.SelecionarTodos();
        }
    }
}
