using WPFAppConverter.Core;
using WPFAppConverter.Core.CoinAnalitic;
using WPFAppConverter.MVVM.ViewModel.Pages;

namespace WPFAppConverter.MVVM.ViewModel
{
    public class CurrentViewModel : ObservableObject
    {
        #region model switch command.
        public RelayCommand HomeCommand { get; set; }
        public RelayCommand AnaliticCommand { get; set; }
        public RelayCommand SettingCommand { get; set; }
        public RelayCommand ExchangeCommand { get; set; }
        public RelayCommand ConvertCommand { get; set; }

        public RelayCommand CurrencyCommand { get; set; }

        public RelayCommand LastPageCommand { get; set; }
        #endregion

        #region view model.
        public HomeModel HomeVM             { get; set; }
        public AnaliticModel AnaliticVM     { get; set; }
        public SettingModel SettingVM       { get; set; }
        public ConvertModel ConvertVM       { get; set; }
        public ExchangesModel ExchangesVM   { get; set; }
        public CurrencyModel CurrencyVM     { get; set; }
        #endregion

        /* last view page */
        private object _lastView;
        public object LastView
        {
            get { return _lastView; }
            set { _lastView = value; }
        }

        /* current view page */
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != null)
                    LastView = _currentView;
                _currentView = value;
                OnPropentyChanged();
            }
        }

        public CurrentViewModel()
        {
            /* Intialization model */
            HomeVM = new HomeModel();
            AnaliticVM = new AnaliticModel();
            SettingVM = new SettingModel();
            ConvertVM = new ConvertModel();
            ExchangesVM = new ExchangesModel();

            this.CurrentView = this.HomeVM;

            /* Реалізація команд перемикання сторінок (навігації) */
            LastPageCommand = new RelayCommand(o => { CurrentView = LastView; });
            HomeCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            AnaliticCommand = new RelayCommand(o => { CurrentView = AnaliticVM; });
            SettingCommand = new RelayCommand(o => { CurrentView = SettingVM; });
            ConvertCommand = new RelayCommand(o => { CurrentView = ConvertVM; });
            ExchangeCommand = new RelayCommand(o => { CurrentView = ExchangesVM; });

            CurrencyCommand = new RelayCommand(
                    param =>
                    {
                        if (param is CoinStruct _coin)
                        {
                            CurrencyVM = new CurrencyModel { Coin = _coin };
                            CurrentView = CurrencyVM;
                        }
                    }
                );
        }
    }
}
