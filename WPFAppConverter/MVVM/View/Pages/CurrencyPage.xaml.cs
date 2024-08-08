using Microsoft.VisualBasic;
using ScottPlot;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.MVVM.ViewModel;
using WPFAppConverter.MVVM.ViewModel.Pages;

namespace WPFAppConverter.MVVM.View.Pages
{
    public partial class CurrencyPage : Page
    {
        private CoinCap _coinCap;
        private List<CoinStructCandles> _candles;
        private Dictionary<string, CoinStructMarkets> _market;

        public CoinStruct _coin { get; set; }

        private CurrentViewModel _currentVM;

        public CurrencyPage()
        {
            InitializeComponent();
            InitializationDataGrid();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];

            // Initialization CurrentViewModel
            _currentVM = (CurrentViewModel)Application.Current.Resources["currentViewModel"];
            _coin = _currentVM.CurrencyVM.Coin; // Assign the transferred value

            DataContext = this;
        }

        private async void LoadingPage(object sender, RoutedEventArgs e)
        {
            // Getting values about currency
            // TODO : Автоматизировать 
            _candles = await _coinCap.GetCandles(_coin.id, "poloniex", "m30", "ethereum");
            _market = await _coinCap.GetElementMarkets(_coin.id);

            TimeSpan interval = TimeSpan.FromMinutes(30);
            var ohlcs = _candles.Select(c => new OHLC(
                (double)c.open,
                (double)c.high,
                (double)c.low,
                (double)c.close,
                DateTimeOffset.FromUnixTimeSeconds(c.period).DateTime,
                interval
            )).ToList();


            PlotAnalitic.Plot.Add.Candlestick(ohlcs);
            PlotAnalitic.Plot.Axes.DateTimeTicksBottom();

            ScottPlot.Finance.BollingerBands bb = new(ohlcs, ohlcs.Count);

            var sp1 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.Means);
            sp1.MarkerSize = 0;
            sp1.Color = Colors.Navy;

            var sp2 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.UpperValues);
            sp2.MarkerSize = 0;
            sp2.Color = Colors.Navy;
            sp2.LinePattern = LinePattern.Dotted;

            var sp3 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.LowerValues);
            sp3.MarkerSize = 0;
            sp3.Color = Colors.Navy;
            sp3.LinePattern = LinePattern.Dotted;

            PlotAnalitic.Plot.HideGrid();

            PlotAnalitic.Plot.XLabel("Time");
            PlotAnalitic.Plot.YLabel("Price (USD)");
            PlotAnalitic.Plot.Title("Price Distribution Over Time");

            PlotAnalitic.Refresh();
        }

        /*
         
        
        // generate and plot time series price data
        var prices = Generate.RandomOHLCs(100);
        myPlot.Add.Candlestick(prices);
        myPlot.Axes.DateTimeTicksBottom();

        // calculate Bollinger Bands
        ScottPlot.Finance.BollingerBands bb = new(prices, 20);

        // display center line (mean) as a solid line
        var sp1 = myPlot.Add.Scatter(bb.Dates, bb.Means);
        sp1.MarkerSize = 0;
        sp1.Color = Colors.Navy;

        // display upper bands (positive variance) as a dashed line
        var sp2 = myPlot.Add.Scatter(bb.Dates, bb.UpperValues);
        sp2.MarkerSize = 0;
        sp2.Color = Colors.Navy;
        sp2.LinePattern = LinePattern.Dotted;

        // display lower bands (positive variance) as a dashed line
        var sp3 = myPlot.Add.Scatter(bb.Dates, bb.LowerValues);
        sp3.MarkerSize = 0;
        sp3.Color = Colors.Navy;
        sp3.LinePattern = LinePattern.Dotted;
         
         */

        private void InitializationDataGrid()
        {
            
        }
    }
}
