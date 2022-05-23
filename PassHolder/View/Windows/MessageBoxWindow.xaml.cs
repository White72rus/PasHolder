using PassHolder.ViewModel;

using System.Windows;

namespace PassHolder.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : Window
    {
        private static MessageBoxWindow _instance;

        public MessageBoxWindow()
        {
            InitializeComponent();
            MessageBoxViewModel viewModel = MessageBoxViewModel.GetInstance();
            this.DataContext = viewModel;

            if (viewModel.HidenAction == null)
                viewModel.HidenAction = new System.Action(() => { this.Hide(); });

            if (viewModel.ShowAction == null)
                viewModel.ShowAction = new System.Action(() => { this.Show(); });

            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new System.Action(() => { this.Close(); });
        }

        public static MessageBoxWindow GetInstance()
        {
            if (_instance == null)
                _instance = new MessageBoxWindow();
            return _instance;
        }
    }
}
