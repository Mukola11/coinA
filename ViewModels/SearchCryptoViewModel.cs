using coinA.Commands;
using coinA.Models;
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
    public class SearchCryptoViewModel : ViewModelBase
    {
        private string _searchText;
        private ObservableCollection<SearchCryptoModel> _searchResults;
        private ObservableCollection<SearchCryptoModel> _allCryptos;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChange(nameof(SearchText));
                FilterSearchResults();
            }
        }

        public ObservableCollection<SearchCryptoModel> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChange(nameof(SearchResults));
            }
        }

        public ICommand OnDetailCommand { get; }

        public SearchCryptoViewModel(NavigationStore navigationStore)
        {
            OnDetailCommand = new OnDetailCommand(navigationStore);

            _allCryptos = new ObservableCollection<SearchCryptoModel>
        {
            new SearchCryptoModel { Id = "bitcoin", Symbol = "btc", Name = "Bitcoin" , Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400"},
            new SearchCryptoModel { Id = "ethereum", Symbol = "eth", Name = "Ethereum", Image = "https://assets.coingecko.com/coins/images/279/large/ethereum.png?1696501628" },
            new SearchCryptoModel { Id = "ripple", Symbol = "xrp", Name = "Ripple", Image = "https://assets.coingecko.com/coins/images/44/large/xrp-symbol-white-128.png"},
        };

            SearchResults = new ObservableCollection<SearchCryptoModel>();
        }

        private void FilterSearchResults()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                SearchResults = new ObservableCollection<SearchCryptoModel>(_allCryptos);
            }
            else
            {
                var filteredResults = _allCryptos
                    .Where(c => c.Symbol.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                c.Name.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                SearchResults = new ObservableCollection<SearchCryptoModel>(filteredResults);
            }
        }
    }
}
