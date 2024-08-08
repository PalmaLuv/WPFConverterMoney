using WPFAppConverter.Core;
using WPFAppConverter.Core.CoinAnalitic;

namespace WPFAppConverter.MVVM.ViewModel.Pages
{
    public class CurrencyModel : ObservableObject
    {
        private CoinStruct _coin; 

        public CoinStruct Coin
        {
            get => _coin;
            set
            {
                _coin = value;
                OnPropentyChanged();
            }
        }
    }
}
