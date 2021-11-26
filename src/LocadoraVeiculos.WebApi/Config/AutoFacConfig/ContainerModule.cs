using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Aplicacao.TaxaModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM.TaxaModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoFacConfig
{
    public class ContainerModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //DBCONTEXT
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            //PARCEIRO
            builder.RegisterType<ParceiroOrmDao>().As<IParceiroRepository>();
            builder.RegisterType<ParceiroAppService>().InstancePerDependency();

            //CUPOM
            builder.RegisterType<CupomOrmDao>().As<ICupomRepository>();
            builder.RegisterType<CupomAppService>().InstancePerDependency();

            //FUNCIONARIO
            builder.RegisterType<FuncionarioOrmDao>().As<IFuncionarioRepository>();
            builder.RegisterType<FuncionarioAppService>().InstancePerDependency();

            //TAXA
            builder.RegisterType<TaxaOrmDao>().As<ITaxaRepository>();
            builder.RegisterType<TaxaAppService>().InstancePerDependency();


            builder.RegisterType<Mapper>().As<IMapper>();

            builder.RegisterType<Notificador>().As<INotificador>().InstancePerLifetimeScope();
        }
      

    }
}
