using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {

        private CoinCap _coinCap;

        public HomePage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];
        }

        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            Dictionary<string, CoinStruct> coinList = await _coinCap.GetAssetsAll("?limit=10");
            var columns = new List<(string Header, string BindingPath)> // Columnns name
            {
                ("Rank", "rank"),
                ("Symbol", "symbol"),
                ("Name", "name"),
                ("24h Volume (USD)", "volumeUsd24Hr"),
                ("Price (USD)", "priceUsd"),
                ("Change % (24h)", "changePercent24Hr"),
                ("VWAP (24h)", "vwap24Hr")
            };

            foreach (var column in columns)
            {
                this.top_assets.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
                    { Converter = new DecimalFormatConverter() }
                });
            }

            var list = new ObservableCollection<CoinStruct>(coinList.Values);
            this.top_assets.ItemsSource = list;

            resizeDataGrid(this.top_assets, coinList.Count);
        }

        // Dynamic resize dataGrid.
        private void resizeDataGrid(DataGrid _dataGrid, int count)
        {
            double rowHeight = 40;
            double headerHeight = _dataGrid.ColumnHeaderHeight;
            double totalHeight = count * rowHeight + headerHeight;

            _dataGrid.Height = totalHeight;
        }
    }
}
