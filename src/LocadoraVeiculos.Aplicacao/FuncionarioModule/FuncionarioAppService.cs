using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public interface IFuncionarioAppService
    {
        List<Funcionario> SelecionarTodos();

        string RegistrarNovoFuncionario(Funcionario funcionario);
        Funcionario SelecionarPorId(int id);
        string ExcluirFuncionario(int id);

        string EditarFuncionario(int id, Funcionario funcionario);
    }

    public class FuncionarioAppService : ICadastravel<Funcionario>
    {

        private const string IdFuncionario_Format = "[Id do Funcionario: {FuncionarioId}]";

        private const string FuncionarioRegistrado_ComSucesso =
            "Funcionario registrado com sucesso";

        private const string FuncionarioNaoRegistrado =
            "Funcionario NÃO registrado. Tivemos problemas com a inserção no banco de dados ";


        private const string FuncionarioNaoEditado =
         "Funcionario não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string FuncionarioEditado_ComSucesso =
            "Funcionario editado com sucesso";

        private const string FuncionarioNaoExcluido =
           "Funcionario não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string FuncionarioExcluido_ComSucesso =
            "Funcionario excluído com sucesso";

        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly INotificador notificador;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository, INotificador notificador)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.notificador = notificador;
        }

        public bool Editar(int id, Funcionario funcionario)
        {
            FuncionarioValidator validator = new FuncionarioValidator();

            var resultado = validator.Validate(funcionario);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }


         


            var funcionarioEditado = funcionarioRepository.Editar(id, funcionario);

            if (funcionarioEditado == false)
            {
                Log.Logger.Aqui().Warning(FuncionarioNaoEditado + IdFuncionario_Format, id);

                notificador.RegistrarNotificacao(FuncionarioNaoEditado);

                return false;
            }

            return true;
        }

    

        public bool Excluir(int id)
        {
            var funcionarioExcluido = funcionarioRepository.Excluir(id);

            if (funcionarioExcluido == false)
            {
                Log.Logger.Aqui().Warning(FuncionarioNaoExcluido + IdFuncionario_Format, id);

                notificador.RegistrarNotificacao(FuncionarioNaoExcluido);

                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            var funcionario = funcionarioRepository.SelecionarPorId(id);

            if (funcionario == null)
                return false;

            return true;
        }

        public bool InserirNovo(Funcionario funcionario)
        {
            FuncionarioValidator validator = new FuncionarioValidator();

            var resultado = validator.Validate(funcionario);

            if (resultado.IsValid == false)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }

                return false;
            }

          
            var funcionarioInserido = funcionarioRepository.Inserir(funcionario);

            if (funcionarioInserido == false)
            {
                Log.Logger.Aqui().Warning(FuncionarioNaoRegistrado + IdFuncionario_Format, funcionario.Id);

                notificador.RegistrarNotificacao(FuncionarioNaoRegistrado);

                return false;
            }

            return true;
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }


        public List<Funcionario> SelecionarTodos()
        {
            return funcionarioRepository.SelecionarTodos();
        }
    }
}
