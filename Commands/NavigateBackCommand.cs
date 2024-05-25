using coinA.Stores;
using coinA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinA.Commands
{
    public class NavigateBackCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateBackCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            var navigateCommand = new NavigateCommand(_navigationStore, new TopCryptoViewModel(_navigationStore));
            navigateCommand.Execute(parameter);
        }
    }
}
