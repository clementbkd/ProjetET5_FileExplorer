//Intégration de Unity

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Prism.Sample.ModuleA;
//using Prism.Sample.ModuleB;
using FolderBrowser;
using Prism.Sample.ModuleC;
using Prism.Sample.ModuleD;
using System.Windows;

namespace Prism.Sample.Explorer
{
    //On utilise le framework Unity pour les dépendeances du BootStrapper

    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<PrismShell>();
        }

        //Charger l'application PrismShell  
        protected override void InitializeModules()
        {

            base.InitializeModules();
            Application.Current.MainWindow = (PrismShell)Shell;
            Application.Current.MainWindow.Show();
        }
        //Charger les différents modules du Catalog que l'on souhaite afficher à travers le PrismShell
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(AModule));
            moduleCatalog.AddModule(typeof(BModule));
            moduleCatalog.AddModule(typeof(CModule));
            moduleCatalog.AddModule(typeof(DModule));
        }
    }
}
