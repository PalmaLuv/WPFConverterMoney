using System.Windows;
using System.Windows.Input;

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

            //DataContext = this;

            TitleMainWindow = "Converter";
        }

        public void LoadingMainWindow(object sender, RoutedEventArgs e)
        {
            //Loading Forms 
        }


        #region header button func.
        private void HeaderMouse(object sender, MouseButtonEventArgs e) // Moving mainWindow
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void WindowClose(object sender, RoutedEventArgs e) => Application.Current.Shutdown(); // Close mainWindow
        private void Maximization(object sender, RoutedEventArgs e) =>                                // Max size mainWindow
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

        private void Minimazation(object sender, RoutedEventArgs e) =>                                // Min size mainWindow
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        #endregion
    }
}