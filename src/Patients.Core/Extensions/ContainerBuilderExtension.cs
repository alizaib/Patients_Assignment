using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Patients.Core.Extensions {
    public static class ContainerBuilderExtension {
        public static void AddMediator(this ContainerBuilder builder, IEnumerable<Assembly> assemblies) {
            builder.RegisterType<Mediator>()
                   .As<IMediator>()
                   .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context => {
                var c = context.Resolve<IComponentContext>();

                return c.Resolve;
            });

            var genericRequestHandlerType = typeof(ADBRequestHandler<,,>);

            foreach (var assembly in assemblies) {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(t => t.InheritsGenericClass(genericRequestHandlerType))
                    .AsImplementedInterfaces();
            }
        }
    }
}
