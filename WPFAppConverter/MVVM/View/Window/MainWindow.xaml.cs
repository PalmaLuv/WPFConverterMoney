using System.Windows;

namespace WPFAppConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TitleMainWindow { get; private set; }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            TitleMainWindow = "Converter";
        }

        public void LoadingMainWindow(object sender, RoutedEventArgs e)
        {
            //Loading Forms 
        }

        private void HeaderMouse(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}