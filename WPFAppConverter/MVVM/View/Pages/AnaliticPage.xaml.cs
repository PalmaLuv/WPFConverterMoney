using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.ConverterNumber;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnaliticPage.xaml
    /// </summary>
    public partial class AnaliticPage : Page
    {
        private CoinCap _coinCap;

        public AnaliticPage()
        {
            InitializeComponent();

            // Initializetion coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];
        }

        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            Dictionary<string, CoinStruct> value =  await _coinCap.GetAssetsAll();
            this.allCrypto.ItemsSource = new ObservableCollection<CoinStruct>(value.Values);

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