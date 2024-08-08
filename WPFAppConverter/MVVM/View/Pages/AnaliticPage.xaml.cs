using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;
using WPFAppConverter.MVVM.View.Window.Components;
using WPFAppConverter.MVVM.ViewModel;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnaliticPage.xaml
    /// </summary>
    public partial class AnaliticPage : Page
    {
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

        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            _dictionaryCoin = await _coinCap.GetAssetsAll();
            _coins = new ObservableCollection<CoinStruct>(_dictionaryCoin.Values);
            _dataView = CollectionViewSource.GetDefaultView(_coins);
            this.allCrypto.ItemsSource = _dataView;

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
                this.allCrypto.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(column.BindingPath)
                    { Converter = new DecimalFormatConverter() }
                });
            }

            // ---- TEST ----
            var _curr = Application.Current.Resources["currentViewModel"] as CurrentViewModel;
            ButtonTest.Command = _curr.CurrencyCommand;
            CoinStruct _coin = _dictionaryCoin["bitcoin"];
            ButtonTest.CommandParameter = _coin;
        }

        // Search func [Name]
        private void SearchTextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is SearchBox _search)
            {
                _dataView.Filter = item =>
                {
                    if (string.IsNullOrEmpty(_search.Text))
                        return true;

                    var keyValuePair = (CoinStruct)item;
                    return keyValuePair.name.IndexOf(_search.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                };
            }
        }
    }
}

/*
 
 public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }

        public decimal supply { get; set; }
        public decimal? maxSupply { get; set; }
        public decimal marketCapUsd { get; set; }
        public decimal volumeUsd24Hr { get; set; }
        public decimal priceUsd { get; set; }
        public decimal changePercent24Hr { get; set; }
        public decimal vwap24Hr { get; set; }

 */