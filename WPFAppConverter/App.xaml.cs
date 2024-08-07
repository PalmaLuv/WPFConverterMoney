using System.Windows;
using WPFAppConverter.Core.CoinAnalitic;

namespace WPFAppConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setting the Title of the programme from the parameters
            this.Resources["TitleForms"] = WPFAppConverter.Properties.Settings.Default.TitleName;
        }
    }

}
