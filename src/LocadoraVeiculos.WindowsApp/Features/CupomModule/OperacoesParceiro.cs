﻿using LocacaoVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.CupomModule
{
    public class OperacoesParceiro : ICadastravel
    {
        private TabelaParceiroControl tabelaParceiros;

        private readonly IParceiroAppService parceiroService;

        public OperacoesParceiro(IParceiroAppService parceiroService)
        {
            this.parceiroService = parceiroService;
        }

        public void InserirNovoRegistro()
        {
            var tela = new TelaParceiroForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Parceiro parceiro = tela.Parceiro;

                var resultado = parceiroService.RegistrarNovoParceiro(parceiro);

                TelaPrincipalForm.Instancia.AtualizarRodape(resultado);

                var registros = parceiroService.SelecionarTodos();

                tabelaParceiros.AtualizarRegistros(registros);

                Log.Logger.Aqui().FuncionalidadeUsada();
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaParceiros.ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um parceiro para poder editar!", "Edição de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaParceiroForm();

            var parceiroSelecionado = parceiroService.SelecionarPorId(id);

            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Parceiro parceiro = tela.Parceiro;

                var resultado = parceiroService.EditarParceiro(parceiro.Id, parceiro);

                TelaPrincipalForm.Instancia.AtualizarRodape(resultado);

                var registros = parceiroService.SelecionarTodos();

                tabelaParceiros.AtualizarRegistros(registros);

                Log.Logger.Aqui().FuncionalidadeUsada();
            }
        }

        public void ExcluirRegistro()
        {
            var id = tabelaParceiros.ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um parceiro para poder exluir!", "Exclusão de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var parceiroSelecionado = parceiroService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o parceiro: [{parceiroSelecionado.Id}] ?", "Exclusão de Cupons",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                parceiroService.ExcluirParceiro(parceiroSelecionado.Id);

                var registros = parceiroService.SelecionarTodos();

                tabelaParceiros.AtualizarRegistros(registros);

                Log.Logger.Aqui().FuncionalidadeUsada();
            }
        }

        public UserControl ObterTabela()
        {
            if (tabelaParceiros == null)
                tabelaParceiros = new TabelaParceiroControl();

            var registros = parceiroService.SelecionarTodos();

            tabelaParceiros.AtualizarRegistros(registros);

            return tabelaParceiros;
        }
    }
}
