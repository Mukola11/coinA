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


    public class TopCryptoViewModel : ViewModelBase
    {
        private string _searchText;

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

        public ICommand OnSearchCommand { get; }

        public ICommand OnDetailCommand { get; }

        public TopCryptoViewModel(NavigationStore navigationStore)
        {
            OnSearchCommand = new OnSearchCommand(navigationStore, this);

            OnDetailCommand = new OnDetailCommand(navigationStore);

            TopCryptoModel = new ObservableCollection<TopCryptoModel>
            {
                new TopCryptoModel
                {
                    Id = "bitcoin",
                    Symbol = "btc",
                    Name = "Bitcoin",
                    Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                    CurrentPrice = 70005,
                    MarketCap = 1379506765043,
                    TotalVolume = 33785648257
                },
                new TopCryptoModel
                {
                    Id = "ethereum",
                    Symbol = "eth",
                    Name = "Ethereum",
                    Image = "https://assets.coingecko.com/coins/images/279/large/ethereum.png?1696501628",
                    CurrentPrice = 3742.31M,
                    MarketCap = 450267431131,
                    TotalVolume = 32803629327
                }

            };
        }


    }
}
