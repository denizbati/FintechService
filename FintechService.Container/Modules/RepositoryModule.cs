using Autofac;
using FintechService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Module = Autofac.Module;

namespace FintechService.Container.Modules
{
    public class RepositoryModule : Module
    {
        private static string _connectionString;

        public static void AddDbContext(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            _connectionString = configuration["DbConnString"];

            serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<FintechServiceDbContext>(options => options.UseSqlServer(_connectionString));
        }
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyType = typeof(FintechServiceDbContext).GetTypeInfo();
            builder.RegisterAssemblyTypes(assemblyType.Assembly)
                .Where(x => x != typeof(FintechServiceDbContext))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }


    }
}
