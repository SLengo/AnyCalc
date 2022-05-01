using AnyCalc.Common;
using System.Windows;

namespace AnyCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CalcsStorage.Instance.InitAllCalcs();
        }
    }
}
