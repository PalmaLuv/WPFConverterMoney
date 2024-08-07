using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFAppConverter.MVVM.View.Window.Components
{
    /// <summary>
    /// Логика взаимодействия для SearchPanel.xaml
    /// </summary>
    public partial class SearchPanel : UserControl
    {
        public string Wotermark
        {
            get { return (string)GetValue(WotermarkProperty); }
            set { SetValue(WotermarkProperty, value); }
        }

        public static readonly DependencyProperty WotermarkProperty =
            DependencyProperty.Register("Wotermark", typeof(string), typeof(SearchPanel), new PropertyMetadata(string.Empty));

        public SearchPanel()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
