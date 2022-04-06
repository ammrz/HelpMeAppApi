using Autofac;
using HelpMeApp.Application.Handlers.Domain.Commands;
using HelpMeApp.Infrastructure.Context;
using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HelpMeApp.Application.Handlers.Domain.Commands.AddDomainCommand;

namespace HelpMeApp.Api.Container
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<HelpMeAppDbContext>().As<HelpMeAppDbContext>()
                   .InstancePerLifetimeScope();
        }
    }
}
