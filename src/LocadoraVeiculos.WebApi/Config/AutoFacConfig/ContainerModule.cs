using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.Infra.ORM.FuncionarioModule;
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
            builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>();

            //CUPOM
            builder.RegisterType<CupomOrmDao>().As<ICupomRepository>();
            builder.RegisterType<CupomAppService>().As<ICupomAppService>();

            //CUPOM
            builder.RegisterType<FuncionarioOrmDao>().As<IFuncionarioRepository>();
            builder.RegisterType<FuncionarioAppService>().As<IFuncionarioAppService>();


            builder.RegisterType<Mapper>().As<IMapper>();

            builder.RegisterType<Notificador>().As<INotificador>().InstancePerLifetimeScope();
        }
      

    }
}
