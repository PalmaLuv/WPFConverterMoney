using System.Windows;

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

        // Function for changing application themes
        public void ChangeTheme(Uri themeUri)
        {
            Current.Resources.MergedDictionaries[0] = new ResourceDictionary { Source = themeUri };
            foreach (Window window in Current.Windows)
            {
                window.InvalidateVisual();
                window.UpdateLayout();
            }
        }
    }

}
