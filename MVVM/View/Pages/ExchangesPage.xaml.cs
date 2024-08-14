using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Navigation;

using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;
using WPFAppConverter.MVVM.View.Window.Components;

namespace WPFAppConverter.MVVM.View.Pages
{
    public partial class ExchangesPage : Page
    {
        // Variables for saving data locally
        private CoinCap _coinCap;
        private Dictionary<string, CoinStructExchanges> _dictionaryExchanges;
        private ObservableCollection<CoinStructExchanges> _coins;
        private ICollectionView _dataView;

        public ExchangesPage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];

            // Initialization exchanges
            _dictionaryExchanges = Task.Run(async () => await _coinCap.GetExchanges())
                .GetAwaiter().GetResult();
        }

        // Function of page loading after initialization
        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            _coins = new ObservableCollection<CoinStructExchanges>(_dictionaryExchanges.Values);
            _dataView = CollectionViewSource.GetDefaultView(_coins);
            InitializationDataGrid();
        }

        private void InitializationDataGrid()
        {
            // Data transfer to the table
            this.allExchanges.ItemsSource = _dataView;

            // Column name and data bound to it
            var columns = new List<(string Header, string BindingPath)>
            {
                ("Rank", "rank"),
                ("Name", "name"),
                ("Daily Volume", "percentTotalVolume"),
                ("Daily Volume (USD)", "volumeUsd"),
                ("Trading Pairs", "tradingPairs"),
                ("URL", "exchangeUrl"),
                //("Socket", "Socket"),
                ("Date updated", "updated")
            };

            foreach (var column in columns)
                if (column.BindingPath == "exchangeUrl")
                {
                    var hyperlinkFactory = new FrameworkElementFactory(typeof(TextBlock)); // Create a FrameworkElementFactory for the TextBlock that will hold the Hyperlink
                    var hyperlink = new FrameworkElementFactory(typeof(Hyperlink));        // Create a FrameworkElementFactory for the Hyperlink

                    // Bind the Hyperlink's NavigateUri property to the data source's property
                    hyperlink.SetBinding(Hyperlink.NavigateUriProperty, new Binding(column.BindingPath));
                    // Add an event handler for the Hyperlink's RequestNavigate event to handle clicks
                    hyperlink.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(Hyperlink_RequestNavigate));
                    var hyperlinkText = new FrameworkElementFactory(typeof(TextBlock));
                    hyperlinkText.SetBinding(TextBlock.TextProperty, new Binding(column.BindingPath));

                    hyperlink.AppendChild(hyperlinkText);       // Add the TextBlock as a child of the Hyperlink
                    hyperlinkFactory.AppendChild(hyperlink);    // Add the Hyperlink as a child of the outer TextBlock

                    this.allExchanges.Columns.Add( new DataGridTemplateColumn // Add the DataGridTemplateColumn to the DataGrid with the configured template
                    {
                        Header = column.Header,
                        CellTemplate = new DataTemplate { VisualTree = hyperlinkFactory }
                    });
                }
                else 
                this.allExchanges.Columns.Add(new DataGridTextColumn // Add a new DataGridTextColumn to the DataGrid
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
                    { Converter = new DecimalFormatConverter() }
                });

        }

        // RequestNavigate event handler
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        // Search func [Name]
        private void SearchTextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is SearchBox _search) // Check for SearchBox type
                _dataView.Filter = item =>
                {
                    if (string.IsNullOrEmpty(_search.Text)) // Checking for zero values
                        return true;

                    return ((CoinStructExchanges)item)
                            .name.IndexOf(_search.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                };
        }
    }
}
