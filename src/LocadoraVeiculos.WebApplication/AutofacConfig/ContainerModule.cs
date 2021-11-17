using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace LocadoraVeiculos.WebApplication.AutofacConfig
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<ParceiroOrmDao>().As<IParceiroRepository>();

            builder.RegisterType<CupomOrmDao>().As<ICupomRepository>();

            builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>();

            builder.RegisterType<CupomAppService>().As<ICupomAppService>();

            builder.RegisterType<Mapper>().As<IMapper>();

        }
    }
}