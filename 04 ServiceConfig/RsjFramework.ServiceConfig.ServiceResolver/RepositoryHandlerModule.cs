using Autofac;
using RsjFramework.ApplicationService;
using RsjFramework.Contracts;
using System.Linq;
using System.Reflection;

namespace RsjFramework.ServiceConfig.ServiceResolver
{
    public class RepositoryHandlerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().SingleInstance();
            builder.RegisterType<DomainEventHandlingExecutor>().As<IDomainEventHandlingExecutor>();
            RegisterEventHandlersFromDomainModel(builder);

            builder.RegisterGeneric(typeof(EfRepository<,>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(EfRepository<,>)).As(typeof(IAsyncRepository<>));
        }

        private static void RegisterEventHandlersFromDomainModel(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load(typeof(BaseSpecification<>).GetTypeInfo().Assembly.GetName().Name))
                .Where(t => t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IHandler<>))))
                .AsImplementedInterfaces();
        }
    }
}
