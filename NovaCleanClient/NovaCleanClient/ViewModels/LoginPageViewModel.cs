using NovaCleanClient.Services.BackendServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCleanClient.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _email, _password, _message="";
        private DelegateCommand _loginCommand;
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Message { get => _message; set => SetProperty(ref _message, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public DelegateCommand LoginCommand { get => _loginCommand ?? (_loginCommand = new DelegateCommand(LoginCommand_Execute)); }
        private ILoginService _loginService;
        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService):base(navigationService)
        {
            _loginService = loginService;
            Email = "eescudero@novaclean.com.ar";
            Password = "password";
            LoginCommand_Execute();
        }
        async void LoginCommand_Execute()
        {
            Message = "Iniciando sesión";
            if (await _loginService.LogIn(Email, Password))
            {
                await NavigationService.NavigateAsync("/NovaMasterDetailPage1/NavigationPage/DaysVisitPage");
            }
            else
            {
                Message = "Email o contraseña incorrectos.";
            }
        }
    }
}
