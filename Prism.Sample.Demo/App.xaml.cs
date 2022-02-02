using System.Windows;

namespace Prism.Sample.Explorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Chargement du Bootstrapper qui a pour rôle de connecter les modules vers l'application
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BootStrapper bootstrapper = new BootStrapper();
            bootstrapper.Run();
        }
    }
}
