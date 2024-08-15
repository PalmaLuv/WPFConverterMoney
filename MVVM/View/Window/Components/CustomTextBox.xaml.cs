using System.Windows;
using System.Windows.Controls;

namespace WPFAppConverter.MVVM.View.Window.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        // Define the TextChanged event
        public event RoutedEventHandler TextChanged;

        // Default text at null value 
        private string _wotermark = "None";

        public string Wotermark
        {
            get { return (string)GetValue(WotermarkProperty); }
            set 
            { 
                if (string.IsNullOrEmpty(value)) // checking zero
                    SetValue(WotermarkProperty, _wotermark);
                else
                    SetValue(WotermarkProperty, value); 
            }
        }

        public static readonly DependencyProperty WotermarkProperty =
            DependencyProperty.Register("Wotermark", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));

        // Add parametr Title
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));

        /* Parameters for working with dimensions */

        private int _minWidth = 170;
        public int MinWidth { get { return _minWidth; } private set { _minWidth = value; } }

        private int _minHeight = 50;
        public int MinHeigh { get { return _minHeight; } private set { _minHeight = value; } }

        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(int), typeof(CustomTextBox), new PropertyMetadata(null));

        public int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(CustomTextBox), new PropertyMetadata(null));

        public CustomTextBox()
        {
            InitializeComponent();

            DataContext = this;
        }

        // Expand the Text property to make it easier to access it 
        public string Text
        {
            get => PART_TextBox.Text;
            set => PART_TextBox.Text = value;
        }

        private void PART_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox search)
                if (string.IsNullOrEmpty(search.Text))
                    search.Tag = Wotermark;
                else
                    search.Tag = null;

            TextChanged?.Invoke(this, new RoutedEventArgs());
        }
    }
}