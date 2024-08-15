using System.Windows;
using System.Windows.Controls;

namespace WPFAppConverter.MVVM.View.Pages
{
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void LoadingPage(object sender, RoutedEventArgs e)
        {

            // Selecting a theme based on the one saved in the parameters
            var theme = Properties.Settings.Default.Theme;
            if (!string.IsNullOrEmpty(theme))
                foreach (ComboBoxItem item in ComboTheme.Items)
                    if (item.Content.ToString() == theme)
                    {
                        ComboTheme.SelectedItem = item;
                        break;
                    }
        }

        // Applying a theme to an application and saving it in the settings 
        private void ApplyThemeButtonClick(object sender, RoutedEventArgs e)
        {
            if (ComboTheme.SelectedItem != null)
            {
                ComboBoxItem selectedItem = ComboTheme.SelectedItem as ComboBoxItem;
                var lightThemeUri = new Uri(
                    $"MVVM/View/Window/Style/ApplicationStyle.{selectedItem.Content.ToString().ToLower()}.xaml",
                    UriKind.Relative);
                ((App)Application.Current).ChangeTheme(lightThemeUri);

                Properties.Settings.Default.Theme = selectedItem.Content.ToString();
                Properties.Settings.Default.Save();
            }
        }
    }
}
