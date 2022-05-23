using PassHolder.ViewModel.Login;

using System.Windows.Controls;

namespace PassHolder.View.Windows.Login
{
    /// <summary>
    /// Логика взаимодействия для NewAccount.xaml
    /// </summary>
    public partial class NewAccount : UserControl
    {
        public NewAccount()
        {
            InitializeComponent();
            NewAccountViewModel viewModel = new NewAccountViewModel();
            this.DataContext = viewModel;

            if (viewModel.CloseAction == null) viewModel.CloseAction = new System.Action(() => { App.Current.Shutdown(); });
        }
    }
}
