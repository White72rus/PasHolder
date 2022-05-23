using PassHolder.Infrastructure.Services.AuthService;

using System.Security;
using System.Windows.Input;

namespace PassHolder.ViewModel.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private IAuthService _authService;
        private SecureString _login;
        private SecureString _password;

        public SecureString Login { get => _login; set => Set(ref _login, value); }
        public SecureString Password { get => _password; set => Set(ref _password, value); }

        public ICommand LoginCommand => RunCommand(() => { OnLogin(); });

        public LoginViewModel()
        {
            _authService = new AuthService();
        }

        private void OnLogin()
        {
            if(_login != null)
                _login.MakeReadOnly();
            if (_password != null)
                _password.MakeReadOnly();

            //_authService.LoginResult = new LoginResult(_login, _password);

            _authService.Auth(new LoginResult(_login, _password));

            CloseDialogWithResult(MainWindowViewModel.GetInstance(), _login, _password);
        }

        private bool ValidationLogin(SecureString secureString)
        {
            return true;
        }
    }
}
