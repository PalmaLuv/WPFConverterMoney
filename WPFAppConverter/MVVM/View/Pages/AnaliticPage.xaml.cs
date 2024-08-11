using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

using WPFAppConverter.MVVM.ViewModel;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;
using WPFAppConverter.MVVM.View.Window.Components;

namespace WPFAppConverter.MVVM.View.Pages
{
    public partial class AnaliticPage : Page
    {
        // Variables for saving data locally
        private CoinCap _coinCap;
        private Dictionary<string, CoinStruct> _dictionaryCoin;
        private ObservableCollection<CoinStruct> _coins;
        private ICollectionView _dataView;

        public AnaliticPage()
        {
            InitializeComponent();

            // Initializetion coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];
        }

        // Function of page loading after initialization
        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            _dictionaryCoin = await _coinCap.GetAssetsAll("?limit=2000"); 
            _coins = new ObservableCollection<CoinStruct>(_dictionaryCoin.Values);
            _dataView = CollectionViewSource.GetDefaultView(_coins);
            InitializationDataGrid();
        }

        private void InitializationDataGrid()
        {
            // Data transfer to the table 
            this.allCrypto.ItemsSource = _dataView;

            // Column name and data bound to it
            var columns = new List<(string Header, string BindingPath)>
            {
                ("Rank", "rank"),
                ("Symbol", "symbol"),
                ("Name", "name"),
                ("24h Volume (USD)", "volumeUsd24Hr"),
                ("Price (USD)", "priceUsd"),
                ("Change % (24h)", "changePercent24Hr"),
                ("VWAP (24h)", "vwap24Hr"),
                ("Action", "_button_")
            };

            foreach (var column in columns)
                if (column.BindingPath == "_button_")
                {
                    // Create a new instance of FrameworkElementFactory to create Button elements
                    // Set the Content property for the button to display the "Details" text
                    var buttonFactory = new FrameworkElementFactory(typeof(Button));
                    buttonFactory.SetValue(ContentProperty, "Details");

                    // Bind a command to go to the currencies page 
                    var _curr = Application.Current.Resources["currentViewModel"] as CurrentViewModel;
                    buttonFactory.SetValue(Button.CommandProperty, _curr.CurrencyCommand);

                    // Bind the command parameter to the current data element (CoinStruct)
                    buttonFactory.SetBinding(Button.CommandParameterProperty, new Binding("."));

                    this.allCrypto.Columns.Add(new DataGridTemplateColumn
                    {
                        Header = column.Header,
                        CellTemplate = new DataTemplate
                        {
                            VisualTree = buttonFactory,
                        }
                    });
                }
                else
                    this.allCrypto.Columns.Add(new DataGridTextColumn
                    {
                        Header = column.Header,
                        Binding = new Binding(column.BindingPath)
                        { Converter = new DecimalFormatConverter() }
                    });
        }

        // Search func [Name]
        private void SearchTextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is SearchBox _search) // Check for SearchBox type
                _dataView.Filter = item =>
                {
                    if (string.IsNullOrEmpty(_search.Text)) // Checking for zero values
                        return true;

                    return ((CoinStruct)item)
                            .name.IndexOf(_search.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                };
        }
    }
}