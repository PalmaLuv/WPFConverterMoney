using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public partial class ConvertPage : Page
    {
        private CoinCap _coinCap;

        private Dictionary<string, CoinStructRates> _rates;

        public ConvertPage()
        {
            InitializeComponent();

            // Initialization coinCap
            _coinCap = (CoinCap)Application.Current.Resources["coinCap"];
        }

        public async void LoadingPage(object sender, RoutedEventArgs e)
        {
            // Initialization rates
            _rates = await _coinCap.GetRatesAll();
        }
    }
}
