using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using DiplomPrint.Modules;
using Microsoft.Practices.ServiceLocation;

namespace DiplomPrint
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            // переопределяем инициализацию окна
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            // КОнфигурируем модули

            // у нас он один
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = "Navigation",
                ModuleType = typeof(NavigationModule).AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // ранее мы инициализировали модель
            // теперь я ещё зарегистрировал его как сервис навигации
            Container.RegisterType<INavigationModule, NavigationModule>();
        }
    }
}
