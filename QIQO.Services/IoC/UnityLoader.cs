using Microsoft.Practices.Unity;
using QIQO.Core.Contracts;
using QIQO.Data;
using QIQO.Data.Interfaces;
using QIQO.Data.Maps;
using QIQO.Data.Repositories;

namespace QIQO.Services.IoC
{
    public static class UnityLoader
    {
        public static IUnityContainer Init()
        {
            IUnityContainer container = new UnityContainer();

            RegisterDBContexts(container);

            // container.RegisterType<ICache, LocalMemoryCache>(new ContainerControlledLifetimeManager());

            RegisterFactories(container);
            RegisterServices(container);
            RegisterBusinessEngines(container);
            RegisterRepositories(container);
            RegisterMaps(container);
            RegisterEntityServices(container);

            return container;
        }

        private static void RegisterDBContexts(IUnityContainer container)
        {
            container.RegisterType<IMainDBContext, MainDBContext>();
        }

        private static void RegisterBusinessEngines(IUnityContainer container)
        {
            //container.RegisterType<IAccountEmployeeBusinessEngine, AccountEmployeeBusinessEngine>();
            //container.RegisterType<IAccountTypeBusinessEngine, AccountTypeBusinessEngine>(new ContainerControlledLifetimeManager());
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ILRPService, LRPService>();
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<ITestRepository, TestRepository>();
        }

        private static void RegisterFactories(IUnityContainer container)
        {
            //container.RegisterType<IBusinessEngineFactory, BusinessEngineFactory>();
            //container.RegisterType<IDataRepositoryFactory, DataRepositoryFactory>();
            //container.RegisterType<IEntityServiceFactory, EntityServiceFactory>();
        }

        private static void RegisterMaps(IUnityContainer container)
        {
            container.RegisterType<ITestMapper, TestMapper>();
        }

        private static void RegisterEntityServices(IUnityContainer container)
        {
            //container.RegisterType<IEntityTypeEntityService, EntityTypeEntityService>();
        }
    }

}
