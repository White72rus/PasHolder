using PassHolder.Infrastructure.Services.AuthService;
using System.Windows.Input;
using System;

namespace PassHolder.ViewModel.Login
{
    public class LoginWindowViewModel : BaseViewModel
    {
        #region Private

        private static LoginWindowViewModel? _instance;
        private IAuthService _authService;

        #endregion

        #region Public properties

        public string Login { get; set; }
        public Action? HidenAction { get; set; }

        #endregion

        public LoginWindowViewModel()
        {
            _authService = new AuthService();
            //View.Windows.MessageBoxWindow.GetInstance();
        }

        public static LoginWindowViewModel GetInstance()
        {
            if(_instance == null)
                _instance = new LoginWindowViewModel();
            return _instance;
        }

        #region Commands

        public ICommand LoadedCommand => RunCommand(() =>
        {

        });

        public ICommand LoginCommand => RunCommand(() =>
        {
            
            //MainWindowViewModel mainWindowVM = MainWindowViewModel.GetInstance();
            //mainWindowVM.ShowAction();
            MainWindow mainWindow = MainWindow.GetInstance();

            OnLogin(out bool result);

            if (result)
            {
                HidenAction?.Invoke();
                mainWindow.Show();
            }
            else
            {
                //MessageBoxWindow.Show("Invalid login");
                MessageBoxViewModel viewModel = MessageBoxViewModel.GetInstance();
                viewModel.Show("Hi man!", "Welcome");
                //DialogService.MessageBox();
            }
                
        });

        #endregion


        #region Methods
        private void OnLogin(out bool result)
        {
            result = false;
            //MainWindowViewModel mainWindowViewModel = MainWindowViewModel.GetInstance();
            //if(mainWindowViewModel != null)
            //{
            //    mainWindowViewModel.Login = Login;
            //    result = mainWindowViewModel.Auth(Login);
            //}

            //switch (_authService.IsAuth(Login))
            //{
            //    case AuthResult.FileNotFound:
            //        break;
            //    case AuthResult.BadLogin:
            //        break;
            //    case AuthResult.Ok:
            //        result = true;
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion
    }
}
