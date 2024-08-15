using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using WPFAppConverter.Core.ResizeForm;

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

            // Apply theme
            ((App)Application.Current).ChangeTheme(
                new Uri($"MVVM/View/Window/Style/ApplicationStyle.{Properties.Settings.Default.Theme.ToLower()}.xaml",
                UriKind.Relative));
        }

        #region header button func.
        private void HeaderMouse(object sender, MouseButtonEventArgs e) // Moving mainWindow
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            WindowStateHelper.UpdateLastKnownLocation(Top, Left);
        }

        private void WindowClose(object sender, RoutedEventArgs e) => Application.Current.Shutdown(); // Close mainWindow
        private void Maximization(object sender, RoutedEventArgs e)                                  // Max size mainWindow
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                MaxBtn.Content = "❐";
                WindowStateHelper.SetWindowSizeToNormal(this);
            }
            else
            {
                MaxBtn.Content = "☐";
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void Minimazation(object sender, RoutedEventArgs e) =>                                // Min size mainWindow
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        #endregion

        #region resize form.
        private HwndSource _hwndSource;
        private void Window_OnSourceInitialized(object sender, EventArgs e)
            => _hwndSource = (HwndSource)PresentationSource.FromVisual(this);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage
            (IntPtr hWmd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        private void ResizeWindow(ResizeDirection direction)
            => SendMessage(_hwndSource.Handle, 0x112, (IntPtr)(61440 + direction), IntPtr.Zero);

        private enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        private void WindowResize_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = (System.Windows.Shapes.Rectangle)sender;
            if (rectangle == null) return;

            if (WindowStateHelper.IsMaximized) return;

            switch (rectangle.Name)
            {
                case "WindowResizeBottom":
                    Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Bottom);
                    break;
                case "WindowResizeLeft":
                    Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Left);
                    break;
                case "WindowResizeRight":
                    Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Right);
                    break;
                case "WindowResizeBottomLeft":
                    Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.BottomLeft);
                    break;
                case "WindowResizeBottomRight":
                    Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.BottomRight);
                    break;
            }
        }

        private void Window_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                Cursor = Cursors.Arrow;
        }

        private void Window_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowStateHelper.SetWindowMaximized(this);
                WindowStateHelper.BlockStateChange = true;

                var screen = ScreenFinder.FindAppropriateScreen(this);
                if (screen != null)
                {
                    Top = screen.WorkingArea.Top;
                    Left = screen.WorkingArea.Left;
                    Width = screen.WorkingArea.Width;
                    Height = screen.WorkingArea.Height;
                }
            }
            else
            {
                if (WindowStateHelper.BlockStateChange)
                {
                    WindowStateHelper.BlockStateChange = false;
                    return;
                }
                
                WindowStateHelper.UpdateLastKnownNormalSize(Width, Height);
                WindowStateHelper.UpdateLastKnownLocation(Top, Left);

            }
        }
        #endregion
    }
}