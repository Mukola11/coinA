using coinA.Stores;
using coinA.ViewModels;

namespace coinA.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModelBase _viewModelBase;

        public NavigateCommand(NavigationStore navigationStore, ViewModelBase viewModelBase)
        {
            _navigationStore = navigationStore;
            _viewModelBase = viewModelBase;

        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelBase;
        }
    }
}
