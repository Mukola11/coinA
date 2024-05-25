using coinA.Stores;
using coinA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Commands
{
    public class OnSearchCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly TopCryptoViewModel _topCryptoViewModel;

        public OnSearchCommand(NavigationStore navigationStore, TopCryptoViewModel topCryptoViewModel)
        {
            _navigationStore = navigationStore;
            _topCryptoViewModel = topCryptoViewModel;
        }

        public override void Execute(object parameter)
        {
            var searchViewModel = new SearchCryptoViewModel(_navigationStore);
            searchViewModel.SearchText = _topCryptoViewModel.SearchText;

            var navigateCommand = new NavigateCommand(_navigationStore, searchViewModel);
            navigateCommand.Execute(parameter);
        }
    }
}
