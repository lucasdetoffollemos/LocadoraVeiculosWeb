﻿using FluentAssertions;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.TestDataBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using System;

namespace LocadoraVeiculos.IntegrationTests.LocacaoModule
{
    [TestClass]
    public class LocacaoOrmDaoTest : IntegrationTestBase
    {

        protected Locacao locacao;
        protected GrupoVeiculo suv;

        protected Veiculo kicks;
        protected Veiculo fusca;

        protected Funcionario beto;
        protected Funcionario joao;

        protected Condutor bruno;

        protected Taxa caderinhaBebe;
        protected Taxa lavacaoCarro;
        protected Taxa gps;

        protected Cupom dezReaisDeDesconto;
        protected Parceiro deko;

        protected DateTime hoje;
        protected DateTime amanha;
        protected DateTime daquiDezDias;
        protected DateTime daquiSeteDias;
        protected Condutor pedro;

        public LocacaoOrmDaoTest() : base()
        {
            ConfigurarDatas();

            InserirGruposEhPlanos();

            InserirVeiculo();

            InserirClienteEhCondutor();

            InserirFuncionarios();

            InserirTaxas();

            InsrirParceiroEhDesconto();

            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateLogger();
        }

        [TestMethod]
        public void DeveInserir_Locacao_UtilizandoORM()
        {
            //arrange
            locacao = new LocacaoDataBuilder()
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(daquiSeteDias)
                .ComDataDeDevolucaoRealizada(daquiSeteDias)
                .DoFuncionario(beto)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
                .DoVeiculo(kicks)
                .ParaCondutor(bruno)
                 .ConfigurarTaxa(caderinhaBebe, EstadoTaxaLocacaoEnum.Adicionada)
                .ConfigurarTaxa(lavacaoCarro, EstadoTaxaLocacaoEnum.Adicionada)
                .ComCupom(dezReaisDeDesconto)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.MeioTanque)
                .ComRelatorioPDF()
                .Build();

            //action
            locacaoRepository.Inserir(locacao);

            //assert
            var locacaoSelecionada = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoSelecionada.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_LocacaoSemTaxas_UtiliznadoORM()
        {
            locacao = new LocacaoDataBuilder()
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(daquiSeteDias)
                .ComDataDeDevolucaoRealizada(daquiSeteDias)
                .DoFuncionario(beto)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
                .DoVeiculo(kicks)
                .ParaCondutor(bruno)
                .ComCupom(dezReaisDeDesconto)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.Completo)
                .Build();

            locacaoRepository.Inserir(locacao);

            var novaLocacao = new LocacaoDataBuilder()
                .NaData(amanha)
                .ComDataDeDevolucaoPrevista(daquiDezDias)
                .ComDataDeDevolucaoRealizada(daquiDezDias)
                .DoFuncionario(joao)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoKmControlado))
                .DoVeiculo(fusca)
                .ParaCondutor(pedro)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.MeioTanque)
                .Build();

            //action
            locacaoRepository.Editar(locacao.Id, novaLocacao);

            //assert
            var locacaoSelecionada = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoSelecionada.Should().Be(novaLocacao);
        }

        [TestMethod]
        public void DeveEditar_LocacaoComTaxas_UtilizandoORM()
        {
            //arrange
            locacao = new LocacaoDataBuilder()
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(daquiSeteDias)
                .ComDataDeDevolucaoRealizada(daquiSeteDias)
                .DoFuncionario(beto)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
                .DoVeiculo(kicks)
                .ParaCondutor(bruno)
                .ConfigurarTaxa(caderinhaBebe, EstadoTaxaLocacaoEnum.Adicionada)
                .ConfigurarTaxa(lavacaoCarro, EstadoTaxaLocacaoEnum.Adicionada)
                .ComCupom(dezReaisDeDesconto)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.Completo)
                .Build();

            locacaoRepository.Inserir(locacao);

            locacao.ConfigurarTaxa(gps, EstadoTaxaLocacaoEnum.Adicionada);
            locacao.ConfigurarTaxa(caderinhaBebe, EstadoTaxaLocacaoEnum.Removida);
            locacao.ConfigurarTaxa(lavacaoCarro, EstadoTaxaLocacaoEnum.Removida);

            //action
            locacaoRepository.Editar(locacao.Id, locacao);

            //assert
            var locacaoSelecionada = locacaoRepository.SelecionarPorId(locacao.Id);

            locacaoSelecionada.TaxasSelecionadas.Should().HaveCount(1);
            locacaoSelecionada.TaxasSelecionadas[0].Should().Be(gps);
        }

        [TestMethod]
        public void DeveExcluir_Locacao_UtilizandoORM()
        {
            //arrange
            locacao = new LocacaoDataBuilder()
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(daquiSeteDias)
                .ComDataDeDevolucaoRealizada(daquiSeteDias)
                .DoFuncionario(beto)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
                .DoVeiculo(kicks)
                .ParaCondutor(bruno)
                .ConfigurarTaxa(caderinhaBebe, EstadoTaxaLocacaoEnum.Adicionada)
                .ComCupom(dezReaisDeDesconto)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.Completo)
                .Build();

            locacaoRepository.Inserir(locacao);

            //action
            locacaoRepository.Excluir(locacao.Id);

            //assert
            var locacaoSelecionada = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoSelecionada.Should().BeNull();
        }

        [TestMethod]
        public void Deve_Retornar_DuasLocacoes()
        {
            //arrange
            locacao = new LocacaoDataBuilder()
               .NaData(hoje)
               .ComDataDeDevolucaoPrevista(daquiSeteDias)
               .ComDataDeDevolucaoRealizada(daquiSeteDias)
               .DoFuncionario(beto)
               .ComPlanoDeCobranca(
                   suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
               .DoVeiculo(kicks)
               .ParaCondutor(bruno)
               .ConfigurarTaxa(caderinhaBebe, EstadoTaxaLocacaoEnum.Adicionada)
               .ComCupom(dezReaisDeDesconto)
               .ComMarcadorCombustivel(MarcadorCombustivelEnum.Completo)
               .Build();

            var novaLocacao = new LocacaoDataBuilder()
              .NaData(amanha)
              .ComDataDeDevolucaoPrevista(daquiDezDias)
              .ComDataDeDevolucaoRealizada(daquiDezDias)
              .DoFuncionario(joao)
              .ComPlanoDeCobranca(
                  suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoKmControlado))
              .DoVeiculo(fusca)
              .ParaCondutor(pedro)
              .ConfigurarTaxa(lavacaoCarro, EstadoTaxaLocacaoEnum.Adicionada)
              .ComMarcadorCombustivel(MarcadorCombustivelEnum.MeioTanque)
              .Build();

            locacaoRepository.Inserir(locacao);
            locacaoRepository.Inserir(novaLocacao);

            //action
            var locacoes = locacaoRepository.SelecionarTodos(carregarTaxas: true);

            //assert
            locacoes.Should().HaveCount(2);
        }



        #region Métodos Privados
        private void InsrirParceiroEhDesconto()
        {
            deko = new Parceiro("Desconto do Deko");

            parceiroRepository.Inserir(deko);

            dezReaisDeDesconto = new Cupom("Dez conto de desconto", 10, new DateTime(2021, 12, 31), deko, 100, TipoCupomEnum.ValorFixo);

            cupomRepository.Inserir(dezReaisDeDesconto);
        }

        private void InserirTaxas()
        {
            caderinhaBebe = new Taxa("Cadeirinha de Bebê", 30, TipoTaxaEnum.CobradoPorDia);
            lavacaoCarro = new Taxa("Lavação de Carro", 30, TipoTaxaEnum.CobradoUmaVez);
            gps = new Taxa("GPS", 20, TipoTaxaEnum.CobradoPorDia);

            taxaRepository.Inserir(caderinhaBebe);
            taxaRepository.Inserir(lavacaoCarro);
            taxaRepository.Inserir(gps);
        }

        private void InserirFuncionarios()
        {
            beto = new Funcionario("Alberto", "beto", "123456", DateTime.Now.Date, 600.0);

            joao = new Funcionario("João Junior", "jj", "321321", DateTime.Now.Date, 1000.0);

            funcionarioRepository.Inserir(beto);
            funcionarioRepository.Inserir(joao);
        }

        private void InserirClienteEhCondutor()
        {
            var flamengo = new Cliente("Flamengo", "Gávea", "9524282242", "", "", "1234567891234", TipoPessoaEnum.Juridica, "contato@empresa.com.br");

            clienteRepository.Inserir(flamengo);

            bruno = new Condutor("Bruno Henrique", "Gávea", "999292107", "3717158", "04791277945", "123456789", new DateTime(2022, 05, 26), flamengo);

            pedro = new Condutor("Pedro Henrique", "Gávea", "999292107", "3717158", "04791277945", "123456789", new DateTime(2022, 05, 26), flamengo);

            condutorRepository.Inserir(bruno);
            condutorRepository.Inserir(pedro);
        }

        private void InserirVeiculo()
        {
            kicks = new Veiculo("QYV9630", "Kicks", "Nissam", 50.000, 50, TipoCombustivelEnum.Gasolina, suv);
            kicks.Imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

            fusca = new Veiculo("QYV9630", "Renegate", "Jeep", 50.000, 50, TipoCombustivelEnum.Gasolina, suv);
            fusca.Imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

            veiculoRepository.Inserir(kicks);
            veiculoRepository.Inserir(fusca);
        }

        private void InserirGruposEhPlanos()
        {
            suv = new GrupoVeiculo("SUV");
            
            suv.AdicionarPlanos(PlanoCobranca.Diario(100, 10));
            suv.AdicionarPlanos(PlanoCobranca.KmControlado(200, 100, 20));
            suv.AdicionarPlanos(PlanoCobranca.KmLivre(300));

            grupoVeiculoRepository.Inserir(suv);
        }

        private void ConfigurarDatas()
        {
            hoje = DateTime.Now.Date;
            amanha = hoje.AddDays(1);
            daquiSeteDias = DateTime.Now.Date.AddDays(7);
            daquiDezDias = DateTime.Now.Date.AddDays(10);
        }

        #endregion
    }
}
