using coinA.Models;
using coinA.Stores;
using coinA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Commands
{
    public class OnDetailCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public OnDetailCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is TopCryptoModel selectedCrypto )
            {
                var detailViewModel = new CryptoDetailViewModel(_navigationStore ,selectedCrypto.Id);
                var navigateCommand = new NavigateCommand(_navigationStore, detailViewModel);
                navigateCommand.Execute(parameter);
            }
            if (parameter is SearchCryptoModel selectedCrypto1)
            {
                var detailViewModel = new CryptoDetailViewModel(_navigationStore, selectedCrypto1.Id);
                var navigateCommand = new NavigateCommand(_navigationStore, detailViewModel);
                navigateCommand.Execute(parameter);
            }
        }
    }
}
