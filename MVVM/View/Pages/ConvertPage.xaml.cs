using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.Core.Func;
using WPFAppConverter.MVVM.View.Window.Components;

namespace WPFAppConverter.MVVM.View.Pages
{
    public partial class ConvertPage : Page
    {
        private CoinCap _coinCap;

        private Dictionary<string, CoinStructRates> _rates;
        private ObservableCollection<CoinStructRates> _ratesCollection;
        private ICollectionView _dataView;

        public ConvertPage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];

            // Initialization rates
            _rates = Task.Run(async () => await _coinCap.GetRatesAll()).GetAwaiter().GetResult();
        }

        public async void LoadingPage(object sender, RoutedEventArgs e)
        {
            _ratesCollection = new ObservableCollection<CoinStructRates>(_rates.Values);
            _dataView = CollectionViewSource.GetDefaultView(_ratesCollection);

            // Initialization datagrid information
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            // Data transfer to the table 
            this.RatesDataGrid1.ItemsSource = _dataView;
            this.RatesDataGrid2.ItemsSource = _dataView;

            // Column name and data bound to it
            var columns = new List<(string Header, string BindingPath)>
            {
                ("Symbol", "symbol"),
                ("Currency Symbol", "currencySymbol"),
                ("Type", "type"),
                ("Rate USD", "rateUsd")
            };

            // Add columns from dataGrid
            DataGridFunc.AddDataGridColumns(this.RatesDataGrid1, columns);
            DataGridFunc.AddDataGridColumns(this.RatesDataGrid2, columns);
        }

        // Action on input text to realise real-time conversions.
        private bool _isUpdatingText = false;   // Avoiding conversion errors
        private void TextBoxChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_isUpdatingText) return;            // Reverse the action if we already have a conversion in progress
                if (sender is CustomTextBox _thisTextBox)     // Checking for the type of the received object
                    if (decimal.TryParse(_thisTextBox.Text, out decimal moneyResult))   // Check data correctness (decimal type)
                        if (RatesDataGrid1.SelectedItem is CoinStructRates fromCurrency &&
                            RatesDataGrid2.SelectedItem is CoinStructRates toCurrency)  // Check and get the selected table elements
                        {
                            _isUpdatingText = true;
                            if (_thisTextBox.Name == "TextBoxConvert1")                                           // Checking which textBox is involved
                                TextBoxConvert2.Text = Convert(moneyResult, toCurrency, fromCurrency).ToString(); // Currency conversion
                            else if (_thisTextBox.Name == "TextBoxConvert2")
                                TextBoxConvert1.Text = Convert(moneyResult, fromCurrency, toCurrency).ToString();
                        }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _isUpdatingText = false;
            }
        }


        /// <summary>
        /// Converts an amount from one currency to another.
        /// </summary>
        /// <param name="amount">The amount to be converted.</param>
        /// <param name="fromCurrency">The source currency.</param>
        /// <param name="toCurrency">The target currency.</param>
        /// <returns>The converted amount.</returns>
        public static decimal Convert(decimal amount, CoinStructRates fromCurrency, CoinStructRates toCurrency)
        {
            // Check that the currency rates are not zero
            if (fromCurrency.rateUsd == 0 || toCurrency.rateUsd == 0)
            {
                throw new ArgumentException("The rate of one of the currencies is zero.");
            }

            // Convert the amount from the source currency to USD
            decimal amountInUsd = amount / fromCurrency.rateUsd;

            // Convert the amount from USD to the target currency
            return amountInUsd * toCurrency.rateUsd;
        }
    }
}
