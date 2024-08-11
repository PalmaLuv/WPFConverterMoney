using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        // Variables for saving data locally
        private CoinCap _coinCap;
        private Dictionary<string, CoinStruct> _dictionaryCoin;
        private ObservableCollection<CoinStruct> _coins;
        private ICollectionView _dataView;

        public HomePage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];
        }

        // Function of page loading after initialization
        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            _dictionaryCoin = await _coinCap.GetAssetsAll("?limit=10");
            _coins = new ObservableCollection<CoinStruct>(_dictionaryCoin.Values);
            _dataView = CollectionViewSource.GetDefaultView(_coins);
            InitializationDataGrid();
        }

        private void InitializationDataGrid()
        {
            // Data transfer to the table 
            this.top_assets.ItemsSource = _dataView;

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
                ("", "view_page")
            };

            // Arrange the columns in the table
            foreach (var column in columns)
                this.top_assets.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
                    { Converter = new DecimalFormatConverter() }
                });

            // Resize the table to fit the number of records (limit of 10 items)
            resizeDataGrid(this.top_assets, _dictionaryCoin.Count);
        }

        // Dynamic resize dataGrid.
        private void resizeDataGrid(DataGrid _dataGrid, int count)
        {
            // Change the number of elements by 10 if it is greater than 10
            count = 10 < count ? 10 : count;

            // Size calculation for elements
            // The task itself is to set the size that will show the top 10 currencies without crooked display.
            double rowHeight = 40;
            double headerHeight = _dataGrid.ColumnHeaderHeight;
            double totalHeight = count * rowHeight + headerHeight;

            // Set the size of the table
            _dataGrid.Height = totalHeight;
        }
    }
}
