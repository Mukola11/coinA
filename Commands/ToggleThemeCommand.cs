using coinA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace coinA.Commands
{
    public class ToggleThemeCommand : CommandBase
    {
        private readonly TopCryptoViewModel _viewModel;

        public ToggleThemeCommand(TopCryptoViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.IsDarkTheme = !_viewModel.IsDarkTheme;
            SetTheme(_viewModel.IsDarkTheme);
        }

        private void SetTheme(bool isDarkTheme)
        {
            if (isDarkTheme)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("/Resources/DarkTheme.xaml", UriKind.RelativeOrAbsolute)
                });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("/Resources/LightTheme.xaml", UriKind.RelativeOrAbsolute)
                });
            }
        }
    }
}
