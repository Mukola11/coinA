using coinA.Commands;
using coinA.Models;
using coinA.Services;
using coinA.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace coinA.ViewModels
{
    public class SearchCryptoViewModel : ViewModelBase
    {
        private readonly CryptoApiService _cryptoApiService;
        private string _searchText;
        private ObservableCollection<SearchCryptoModel> _searchResults;
        private System.Timers.Timer _searchTimer;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChange(nameof(SearchText));
                ResetSearchTimer();
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
            _cryptoApiService = new CryptoApiService();
            OnDetailCommand = new OnDetailCommand(navigationStore);

            SearchResults = new ObservableCollection<SearchCryptoModel>();


            _searchTimer = new System.Timers.Timer(1000); 
            _searchTimer.AutoReset = false;
            _searchTimer.Elapsed += OnSearchTimerElapsed;
        }

        private async Task FilterSearchResultsAsync()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                SearchResults.Clear();
            }
            else
            {
                var searchResults = await _cryptoApiService.SearchCryptosAsync(SearchText);
                SearchResults = new ObservableCollection<SearchCryptoModel>(searchResults);
            }
        }

        private void ResetSearchTimer()
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private async void OnSearchTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await FilterSearchResultsAsync();
        }

    }
}
