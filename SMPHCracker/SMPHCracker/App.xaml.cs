using SMPHCracker.Logic;
using SMPHCracker.Model.Enums;
using System.Windows;

namespace SMPHCracker
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            new Cracker().Execute(ADBCommands.STOPSERVER);

            ThreadController.StopAllThreads();       
        }
    }
}
