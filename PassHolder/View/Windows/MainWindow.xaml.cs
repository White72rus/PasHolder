using PassHolder.ViewModel;

using System.ComponentModel;
using System.Windows;

namespace PassHolder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instans;
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel viewModel = MainWindowViewModel.GetInstance();
            DataContext = viewModel;

            if (viewModel.HidenAction == null)
                viewModel.HidenAction = new System.Action(() => { this.Hide(); });

            if (viewModel.ShowAction == null)
                viewModel.ShowAction = new System.Action(() => { this.Show(); });

            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new System.Action(() => { this.Close(); });

            if (viewModel.DragAction == null)
                viewModel.DragAction = new System.Action(() => { this.DragMove(); });

            if (viewModel.MinimizedAction == null)
                viewModel.MinimizedAction = new System.Action(() => { this.WindowState = WindowState.Minimized; });

            //this.Hide();
        }

        public static MainWindow GetInstance()
        {
            if (_instans == null)
                _instans = new MainWindow();
            return _instans;
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            App.Current.Shutdown(0);
        }

        private void MainAppWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //this.DragMove();
        }
    }
}
