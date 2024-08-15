using ScottPlot;

using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.MVVM.ViewModel;
using ScottPlot.Plottables;

namespace WPFAppConverter.MVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for CurrencyPage.xaml
    /// </summary>
    public partial class CurrencyPage : Page
    {
        // Variables for saving data locally
        private CoinCap _coinCap;
        private List<CoinStructCandles> _candles;
        private Dictionary<string, CoinStructMarkets> _market;
        private List<CoinStructHistory> _history;

        /* Market */
        private ObservableCollection<CoinStructMarkets> _coinsMarket;
        private ICollectionView _dataViewMarket;

        public CoinStruct _coin { get; set; }

        private CurrentViewModel _currentVM;

        public CurrencyPage()
        {
            InitializeComponent();

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
            _candles = await _coinCap.GetCandles(_coin.id, "poloniex", "m30", "ethereum");
            _market = await _coinCap.GetElementMarkets(_coin.id, "?limit=1000"); // use limit 1000 items.
            _history = await _coinCap.GetHistory(_coin.id, "m30");

            if (0 < _candles.Count)
                InitializationPlotOHLC();
            if (0 < _history.Count)
                InitializationPlotAsix();

            _coinsMarket = new ObservableCollection<CoinStructMarkets>(_market.Values);
            _dataViewMarket = CollectionViewSource.GetDefaultView(_coinsMarket);

            InitialazationDataGrid();
        }

        // Initialization datagrid ( markets ) | Auto generated columns
        private void InitialazationDataGrid()
        {
            this.AssetsMarkets.ItemsSource = _dataViewMarket;
        }

        // Using lib 
        private void InitializationPlotOHLC()
        {
            // Set the time interval for each OHLC (Open, High, Low, Close) data point to 30 minutes
            TimeSpan interval = TimeSpan.FromMinutes(30);

            // Convert the raw candle data to a list of OHLC objects
            var ohlcs = _candles.Select(c => new OHLC(
                (double)c.open,  // Open price
                (double)c.high,  // High price
                (double)c.low,   // Low price
                (double)c.close, // Close price
                DateTimeOffset.FromUnixTimeSeconds(c.period).DateTime, // Convert Unix timestamp to DateTime
                interval          // The time interval
            )).ToList();

            // Add the OHLC candlestick data to the plot
            PlotAnalitic.Plot.Add.Candlestick(ohlcs);

            // Set the X-axis to use DateTime ticks for better time representation
            PlotAnalitic.Plot.Axes.DateTimeTicksBottom();

            // Calculate Bollinger Bands for the OHLC data
            ScottPlot.Finance.BollingerBands bb = new(ohlcs, ohlcs.Count);

            // Plot the Bollinger Bands' mean values
            var sp1 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.Means);
            sp1.MarkerSize = 0;
            sp1.Color = Colors.Navy;

            // Plot the upper Bollinger Band with a dotted line pattern
            var sp2 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.UpperValues);
            sp2.MarkerSize = 0;
            sp2.Color = Colors.Navy;
            sp2.LinePattern = LinePattern.Dotted;

            // Plot the lower Bollinger Band with a dotted line pattern
            var sp3 = PlotAnalitic.Plot.Add.Scatter(bb.Dates, bb.LowerValues);
            sp3.MarkerSize = 0;
            sp3.Color = Colors.Navy;
            sp3.LinePattern = LinePattern.Dotted;

            // Hide the default grid for a cleaner look
            PlotAnalitic.Plot.HideGrid();

            // Set the labels for the X and Y axes
            PlotAnalitic.Plot.XLabel("Time");
            PlotAnalitic.Plot.YLabel("Price (USD)");

            // Set the title of the plot
            PlotAnalitic.Plot.Title("Price Distribution Over Time");

            // Refresh the plot to apply all the changes
            PlotAnalitic.Refresh();

        }

        private void InitializationPlotAsix()
        {
            // Transform data
            DateTime[] dates = new DateTime[_history.Count];
            decimal[] prices = new decimal[_history.Count];

            for (int i = 0; i < _history.Count; i++)
            {
                dates[i] = DateTimeOffset.FromUnixTimeMilliseconds(_history[i].time).DateTime;
                prices[i] = _history[i].priceUsd;
            }

            // Add data to the plot
            var scatter = PlotHistory.Plot.Add.Scatter(dates, prices);

            ToolTip toolTip = new ToolTip()
            { Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse, };

            PlotHistory.MouseMove += (s, e) =>
            {
                Point mousePosition = e.GetPosition(PlotHistory); // get mouse position relative to PlotHistory
                Pixel mousePixel = new((int)mousePosition.X, (int)mousePosition.Y); // create a pixel from the mouse position
                Coordinates mouseLocation = PlotHistory.Plot.GetCoordinates(mousePixel);
                DataPoint nearest = scatter.Data.GetNearest(mouseLocation, PlotHistory.Plot.LastRender);


                if (nearest.IsReal)
                {
                    toolTip.IsOpen = true;
                    toolTip.Content = $"Price USD : {_history[nearest.Index].priceUsd}\nDate : {_history[nearest.Index].date}";
                    toolTip.PlacementTarget = PlotHistory;
                }

                if (!nearest.IsReal)
                {
                    toolTip.IsOpen = false;
                }
            };

            scatter.LineWidth = 3;
            scatter.MarkerSize = 10;


            scatter.FillY = true;
            scatter.FillYColor = scatter.Color.WithAlpha(.2);

            // Convert DateTime to milliseconds since the Unix epoch
            double minDateMs = new DateTimeOffset(dates.Min()).ToUnixTimeMilliseconds();
            double maxDateMs = new DateTimeOffset(dates.Max()).ToUnixTimeMilliseconds();
            double minPrice = (double)prices.Min();
            double maxPrice = (double)prices.Max();

            // Set plot axis limits
            PlotHistory.Plot.Axes.SetLimits(minDateMs, maxDateMs, minPrice, maxPrice);

            // Display time labels on the bottom axis
            PlotHistory.Plot.Axes.DateTimeTicksBottom();

            PlotHistory.Plot.HideGrid();

            // Refresh the plot to apply all changes
            PlotHistory.Refresh();
        }

    }
}
