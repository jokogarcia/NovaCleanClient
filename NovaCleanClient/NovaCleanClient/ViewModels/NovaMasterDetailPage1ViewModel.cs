using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaCleanClient.ViewModels
{
    public class NovaMasterDetailPage1ViewModel : BindableBase
    {
        INavigationService _navigationService;
        DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand { get {
            if(_navigateCommand == null)
                {
                    _navigateCommand = new DelegateCommand<string>(NavigateCommand_Execute);
                    
                }
                return _navigateCommand;
            }
        }

        private async void NavigateCommand_Execute(string page)
        {
            await _navigationService.NavigateAsync($"/NovaMasterDetailPage1/NavigationPage/{page}");
            
        }

        public NovaMasterDetailPage1ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
