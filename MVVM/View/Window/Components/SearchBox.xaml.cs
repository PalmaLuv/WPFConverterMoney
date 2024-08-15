using System.Windows;
using System.Windows.Controls;

namespace WPFAppConverter.MVVM.View.Window.Components
{
    public partial class SearchBox : UserControl
    {
        // Define the TextChanged event
        public event RoutedEventHandler TextChanged;

        private string _wotermark = "Search...";

        public string Wotermark { get { return _wotermark; } private set { _wotermark = value; } }

        // Expand the Text property to make it easier to access it
        public string Text
        {
            get => PART_TextBox.Text;
            set => PART_TextBox.Text = value;
        }

        public SearchBox()
        {
            InitializeComponent();
            DataContext = this;
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
