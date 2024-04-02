using Autofac;
using FintechService.Container.Modules;
using FintechService.Domain.PFintechServiceAggregate.Repositories.CustomerRepository;
using FintechService.Repository.RepositoryAggregate.CustomersRepository;

namespace FintechService.Container
{
    public class Bootstrapper
    {
        public static ILifetimeScope Container { get; private set; }

        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new MediatRModule());
            containerBuilder.RegisterModule(new RepositoryModule());
            containerBuilder.RegisterModule(new RepositoryModule());


        }

        public static void SetContainer(ILifetimeScope autofacContainer)
        {
            Container = autofacContainer;
        }
    }
}