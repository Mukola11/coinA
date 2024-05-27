using coinA.Commands;
using coinA.Models;
using coinA.Services;
using coinA.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace coinA.ViewModels
{


    public class TopCryptoViewModel : ViewModelBase
    {
        private readonly CryptoApiService _cryptoApiService;

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChange(nameof(SearchText));
                if (!string.IsNullOrEmpty(_searchText))
                {
                    OnSearchCommand.Execute(null);
                }
            }
        }

        private ObservableCollection<TopCryptoModel> _topCryptoModel;

        public ObservableCollection<TopCryptoModel> TopCryptoModel
        {
            get
            {
                return _topCryptoModel;
            }
            set
            {
                _topCryptoModel = value;
                OnPropertyChange(nameof(TopCryptoModel));
            }
        }

        private bool _isDarkTheme;

        public bool IsDarkTheme
        {
            get { return _isDarkTheme; }
            set
            {
                if (_isDarkTheme != value)
                {
                    _isDarkTheme = value;
                    OnPropertyChange(nameof(IsDarkTheme));
                }
            }
        }

        public ICommand ToggleThemeCommand { get; }

        public ICommand OnSearchCommand { get; }

        public ICommand OnDetailCommand { get; }

        public TopCryptoViewModel(NavigationStore navigationStore)
        {
            OnSearchCommand = new OnSearchCommand(navigationStore, this);

            OnDetailCommand = new OnDetailCommand(navigationStore);

            ToggleThemeCommand = new ToggleThemeCommand(this);

            _cryptoApiService = new CryptoApiService();
            _ = LoadTopCryptoDataAsync();
        }

        private async Task LoadTopCryptoDataAsync()
        {
            var topCryptos = await _cryptoApiService.GetTopCryptosAsync();
            TopCryptoModel = new ObservableCollection<TopCryptoModel>(topCryptos);
        }


    }
}
