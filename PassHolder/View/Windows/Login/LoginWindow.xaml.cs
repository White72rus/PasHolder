using PassHolder.ViewModel.Login;

using System.Windows;

namespace PassHolder.View.Windows.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static LoginWindow _instans;

        public LoginWindow()
        {
            InitializeComponent();

            //LoginWindowViewModel viewModel = LoginWindowViewModel.GetInstance();
            //DataContext = viewModel;

            //if (viewModel.HidenAction == null)
            //    viewModel.HidenAction = new System.Action(() => { this.Hide(); });
        }

        public static LoginWindow GetInstance()
        {
            if (_instans == null)
                _instans = new LoginWindow();
            return _instans;

        }
    }
}
