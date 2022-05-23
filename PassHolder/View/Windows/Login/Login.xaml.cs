using PassHolder.ViewModel.Login;

using System.Security;
using System.Windows.Controls;

namespace PassHolder.View.Windows.Login
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            this.DataContext = viewModel;
        }

        private void OnChangedPasswordBox(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.DataContext == null) return;
            ((LoginViewModel)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
        }

        private void OnChangedLoginBox(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext == null) return;
            SecureString secureString = new SecureString();
            foreach (char item in ((TextBox)sender).Text)
            {
                secureString.AppendChar(item);
            }
            ((LoginViewModel)this.DataContext).Login = secureString;
        }
    }
}
