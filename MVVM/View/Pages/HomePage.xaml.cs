using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.Func;
using WPFAppConverter.MVVM.ViewModel;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        // Variables for saving data locally
        private CoinCap _coinCap;
        private Dictionary<string, CoinStruct> _dictionaryCoin;
        private ObservableCollection<CoinStruct> _coins;
        private ICollectionView _dataView;

        public CurrentViewModel _curr     { get; set; }
        public List<int> countInformation { get; set; }

        public HomePage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];

            // Initialization currentViewModel
            _curr = (CurrentViewModel)Application.Current.Resources["currentViewModel"];

            // Initialization coin
            _dictionaryCoin = Task.Run(async () => await _coinCap.GetAssetsAll("?limit=10"))
                .GetAwaiter().GetResult();

            countInformation = Task.Run(async () => await _coinCap
                .GetElementCount(new[] { "/v2/rates", "/v2/exchanges", "/v2/assets?limit=2000" }))
                .GetAwaiter().GetResult();
            
            DataContext = this;
        }

        // Function of page loading after initialization
        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
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
                ("VWAP (24h)", "vwap24Hr")
            };

            // Arrange the columns in the table
            DataGridFunc.AddDataGridColumns(this.top_assets, columns);

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
