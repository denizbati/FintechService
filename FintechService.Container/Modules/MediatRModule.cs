using Autofac;
using FintechService.Container.Decorator;
using MediatR;
using System.Reflection;

namespace FintechService.Container.Modules
{
    public class MediatRModule : Autofac.Module
    {
    //    protected override void Load(ContainerBuilder builder)
    //    {
    //        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

    //        builder.Register<ServiceFactory>(ctx =>
    //        {
    //            var c = ctx.Resolve<IComponentContext>();
    //            return t => c.Resolve(t);
    //        });

    //        builder.RegisterAssemblyTypes(typeof(HealthCheckQuery).Assembly)
    //            .AsImplementedInterfaces()
    //            .InstancePerLifetimeScope();

    //        builder.RegisterAssemblyTypes(typeof(HealthCheckQueryHandler).Assembly)
    //            .AsClosedTypesOf(typeof(IRequestHandler<,>))
    //            .AsImplementedInterfaces()
    //            .InstancePerLifetimeScope();


    //        builder.RegisterGeneric(typeof(LoggingHandler<,>)).As(typeof(IPipelineBehavior<,>));
    //        builder.RegisterGeneric(typeof(ExceptionHandler<,>)).As(typeof(IPipelineBehavior<,>));
    //        builder.RegisterGeneric(typeof(CacheHandler<,>)).As(typeof(IPipelineBehavior<,>));

    //        base.Load(builder);
    //    }
    }
}