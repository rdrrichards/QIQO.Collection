using Microsoft.Practices.ServiceLocation;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using QIQO.Client.Core;
using QIQO.Client.Services;
using QIQO.Client.Views;
using System.Windows;

namespace QIQO.Client
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return base.CreateModuleCatalog();
            //ModuleCatalog catalog = new ModuleCatalog();
            //catalog.AddModule(typeof(TitleBarModule));
            //return catalog;
        }

        protected override void ConfigureContainer()
        {
            // RegisterTypeIfMissing(typeof(ILRPService), typeof(LRPProxy), true);
            RegisterTypeIfMissing(typeof(ILRPClient), typeof(LRPClient), true);

            base.ConfigureContainer();

            //InitContainer();
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new LoggerAdapter();
        }
    }
}
