﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    [Migration("20211117173138_AdicionandoTabelaParceiroECupom")]
    partial class AdicionandoTabelaParceiroECupom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.Property<int>("LocacoesId")
                        .HasColumnType("int");

                    b.Property<int>("TaxasSelecionadasId")
                        .HasColumnType("int");

                    b.HasKey("LocacoesId", "TaxasSelecionadasId");

                    b.HasIndex("TaxasSelecionadasId");

                    b.ToTable("LocacaoTaxa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ClienteModule.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("CPF")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("CPF");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("RG")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("RG");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBCliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ClienteModule.Condutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("CNH");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataValidadeCnh")
                        .HasColumnType("date")
                        .HasColumnName("DataValidadeCNH");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("RG");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCondutor");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("ParceiroId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("ValorMinimo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.CupomModule.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.FuncionarioModule.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("numeric(18,0)");

                    b.Property<string>("Senha")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usuario")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoVeiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.GrupoVeiculoModule.PlanoCobranca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GrupoVeiculoId")
                        .HasColumnType("int");

                    b.Property<int>("KilometragemLivreInclusa")
                        .HasColumnType("int")
                        .HasColumnName("KilometragemLivreInclusa");

                    b.Property<string>("TipoPlano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorDia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("ValorKMRodado")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculoId");

                    b.ToTable("TBPlanoCobranca");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CondutorId")
                        .HasColumnType("int");

                    b.Property<int?>("CupomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucaoPrevista")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataDevolucaoRealizada")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("date");

                    b.Property<bool>("EmAberto")
                        .HasColumnType("bit");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("MarcadorCombustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanoCobrancaId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuilometragemPercorrida")
                        .HasColumnType("decimal(18,0)");

                    b.Property<byte[]>("Relatorio")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SituacaoEnvioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondutorId");

                    b.HasIndex("CupomId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PlanoCobrancaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TBLocacao");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.TaxaModule.Taxa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoTaxaLocacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoTaxa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadeOcupantes")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GrupoVeiculoId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("image");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumeroChassi")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("QtdLitrosTanque")
                        .HasColumnType("int");

                    b.Property<int>("QtdPortas")
                        .HasColumnType("int");

                    b.Property<double>("Quilometragem")
                        .HasColumnType("float");

                    b.Property<string>("TamanhoPortaMalas")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoCombustivel")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculoId");

                    b.ToTable("TBVeiculo");
                });

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.LocacaoModule.Locacao", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.TaxaModule.Taxa", null)
                        .WithMany()
                        .HasForeignKey("TaxasSelecionadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ClienteModule.Condutor", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ClienteModule.Cliente", "Cliente")
                        .WithMany("Condutores")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_TBCondutor_TBCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.CupomModule.Parceiro", "Parceiro")
                        .WithMany("Cupons")
                        .HasForeignKey("ParceiroId");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.GrupoVeiculoModule.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", "GrupoVeiculo")
                        .WithMany("PlanosCobranca")
                        .HasForeignKey("GrupoVeiculoId")
                        .HasConstraintName("FK_TBPlanoCobranca_TBGrupoVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoVeiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ClienteModule.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .HasConstraintName("FK_TBLocacao_TBCondutor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.CupomModule.Cupom", "Cupom")
                        .WithMany("Locacoes")
                        .HasForeignKey("CupomId")
                        .HasConstraintName("FK_TBLocacao_TBCupom");

                    b.HasOne("LocadoraVeiculos.Dominio.FuncionarioModule.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("FK_TBLocacao_TBFuncionario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.GrupoVeiculoModule.PlanoCobranca", "PlanoCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoCobrancaId")
                        .HasConstraintName("FK_TBLocacao_TBPlanoCobranca")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.VeiculoModule.Veiculo", "Veiculo")
                        .WithMany("Locacoes")
                        .HasForeignKey("VeiculoId")
                        .HasConstraintName("FK_TBLocacao_TBVeiculos")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condutor");

                    b.Navigation("Cupom");

                    b.Navigation("Funcionario");

                    b.Navigation("PlanoCobranca");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", "GrupoVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("GrupoVeiculoId")
                        .HasConstraintName("FK_TBVeiculo_TBGrupoVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoVeiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ClienteModule.Cliente", b =>
                {
                    b.Navigation("Condutores");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.CupomModule.Parceiro", b =>
                {
                    b.Navigation("Cupons");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.GrupoVeiculoModule.GrupoVeiculo", b =>
                {
                    b.Navigation("PlanosCobranca");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.VeiculoModule.Veiculo", b =>
                {
                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
