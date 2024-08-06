using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WPFAppConverter.Core.CoinAnalitic;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private static CoinCap _coin = new CoinCap();

        public HomePage()
        {
            InitializeComponent();
        }

        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            Dictionary<string, CoinStruct> coinList = await _coin.GetAssetsAll("?limit=10");
            var columns = new List<(string Header, string BindingPath)>
            {
                ("Rank", "rank"),
                ("Symbol", "symbol"),
                ("Name", "name"),
                ("Supply", "supply"),
                ("Max Supply", "maxSupply"),
                //("Market Cap (USD)", "marketCapUsd"),
                //("24h Volume (USD)", "volumeUsd24Hr"),
                //("Price (USD)", "priceUsd"),
                //("Change % (24h)", "changePercent24Hr"),
                //("VWAP (24h)", "vwap24Hr")
            };

            foreach (var column in columns)
            {
                this.top_assets.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
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
